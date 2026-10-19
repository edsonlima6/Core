using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationCoreConsole.Workers;

public sealed class ConsoleServiceBusMessageHandler(ILogger<ConsoleServiceBusMessageHandler> logger)
    : IIncomingServiceBusMessageHandler
{
    public Task HandleAsync(IncomingServiceBusMessage message, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Received Service Bus message {MessageId} with subject {Subject} ({BodyLength} bytes).",
            message.MessageId,
            message.Subject,
            message.Body.Length);

        return Task.CompletedTask;
    }
}
