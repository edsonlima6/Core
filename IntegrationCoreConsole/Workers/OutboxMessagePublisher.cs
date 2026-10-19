using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationCoreConsole.Workers;

public sealed class OutboxMessagePublisher(
    IOutboxMessageRepository outboxRepository,
    IServiceBusMessageSender messageSender,
    ILogger<OutboxMessagePublisher> logger)
{
    public async Task PublishPendingAsync(int batchSize, CancellationToken cancellationToken)
    {
        var messages = await outboxRepository.GetPendingAsync(batchSize, cancellationToken);

        foreach (var message in messages)
        {
            await messageSender.SendAsync(
                message.Id.ToString(),
                message.Type,
                message.Payload,
                cancellationToken);

            await outboxRepository.MarkProcessedAsync(message.Id, cancellationToken);
            logger.LogInformation("Outbox message {OutboxMessageId} published to Azure Service Bus.", message.Id);
        }
    }
}
