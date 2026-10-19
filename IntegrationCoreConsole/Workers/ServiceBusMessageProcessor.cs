using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationCoreConsole.Workers;

public sealed class ServiceBusMessageProcessor(
    IIncomingServiceBusMessageHandler messageHandler,
    ILogger<ServiceBusMessageProcessor> logger)
{
    public async Task ProcessAsync(
        IncomingServiceBusMessage message,
        Func<CancellationToken, Task> completeMessageAsync,
        Func<CancellationToken, Task> abandonMessageAsync,
        CancellationToken cancellationToken)
    {
        try
        {
            await messageHandler.HandleAsync(message, cancellationToken);
            await completeMessageAsync(cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Failed to handle Service Bus message {MessageId}.", message.MessageId);
            await abandonMessageAsync(cancellationToken);
        }
    }
}
