using Domain.Entities;
using Domain.Interfaces.Repositories;
using IntegrationCoreConsole.Workers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTest;

[TestClass]
public sealed class IntegrationWorkerTests
{
    [TestMethod]
    public async Task OutboxPublisher_PublishesAndMarksMessagesProcessed()
    {
        var message = new OutboxMessage
        {
            Id = 17,
            Type = "UserCreated",
            Payload = "{\"id\":17}"
        };
        var repository = new FakeOutboxMessageRepository([message]);
        var sender = new RecordingMessageSender();
        var publisher = new OutboxMessagePublisher(repository, sender, NullLogger<OutboxMessagePublisher>.Instance);

        await publisher.PublishPendingAsync(10, CancellationToken.None);

        Assert.AreEqual(1, sender.SentMessages.Count);
        Assert.AreEqual("17", sender.SentMessages[0].MessageId);
        Assert.AreEqual("UserCreated", sender.SentMessages[0].Subject);
        Assert.AreEqual(message.Payload, sender.SentMessages[0].Body);
        CollectionAssert.AreEqual(new[] { 17 }, repository.MarkedProcessedIds.ToArray());
    }

    [TestMethod]
    public async Task Receiver_CompletesMessageAfterHandlerSucceeds()
    {
        var handler = new RecordingIncomingMessageHandler();
        var processor = new ServiceBusMessageProcessor(handler, NullLogger<ServiceBusMessageProcessor>.Instance);
        var completed = false;
        var abandoned = false;
        var message = new IncomingServiceBusMessage("m-1", "UserCreated", "{}");

        await processor.ProcessAsync(
            message,
            _ => { completed = true; return Task.CompletedTask; },
            _ => { abandoned = true; return Task.CompletedTask; },
            CancellationToken.None);

        Assert.AreSame(message, handler.ReceivedMessage);
        Assert.IsTrue(completed);
        Assert.IsFalse(abandoned);
    }

    [TestMethod]
    public async Task Receiver_AbandonsMessageWhenHandlerFails()
    {
        var handler = new RecordingIncomingMessageHandler
        {
            ExceptionToThrow = new InvalidOperationException("temporary failure")
        };
        var processor = new ServiceBusMessageProcessor(handler, NullLogger<ServiceBusMessageProcessor>.Instance);
        var completed = false;
        var abandoned = false;

        await processor.ProcessAsync(
            new IncomingServiceBusMessage("m-2", "UserCreated", "{}"),
            _ => { completed = true; return Task.CompletedTask; },
            _ => { abandoned = true; return Task.CompletedTask; },
            CancellationToken.None);

        Assert.IsFalse(completed);
        Assert.IsTrue(abandoned);
    }

    private sealed class RecordingMessageSender : IServiceBusMessageSender
    {
        public List<(string MessageId, string Subject, string Body)> SentMessages { get; } = [];

        public Task SendAsync(string messageId, string subject, string body, CancellationToken cancellationToken)
        {
            SentMessages.Add((messageId, subject, body));
            return Task.CompletedTask;
        }
    }

    private sealed class RecordingIncomingMessageHandler : IIncomingServiceBusMessageHandler
    {
        public IncomingServiceBusMessage ReceivedMessage { get; private set; }
        public Exception ExceptionToThrow { get; init; }

        public Task HandleAsync(IncomingServiceBusMessage message, CancellationToken cancellationToken)
        {
            ReceivedMessage = message;
            return ExceptionToThrow is null ? Task.CompletedTask : Task.FromException(ExceptionToThrow);
        }
    }

    private sealed class FakeOutboxMessageRepository(IReadOnlyList<OutboxMessage> pendingMessages)
        : IOutboxMessageRepository
    {
        public List<int> MarkedProcessedIds { get; } = [];

        public Task AddAsync(OutboxMessage message) => Task.CompletedTask;

        public Task<IReadOnlyList<OutboxMessage>> GetPendingAsync(int batchSize, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<OutboxMessage>>(pendingMessages.Take(batchSize).ToArray());

        public Task MarkProcessedAsync(int id, CancellationToken cancellationToken = default)
        {
            MarkedProcessedIds.Add(id);
            return Task.CompletedTask;
        }
    }
}
