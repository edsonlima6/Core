using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationCoreConsole.Workers;

public sealed class ServiceBusMessageReceiverWorker(
    ServiceBusProcessor processor,
    ServiceBusMessageProcessor messageProcessor,
    ILogger<ServiceBusMessageReceiverWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        processor.ProcessMessageAsync += args => messageProcessor.ProcessAsync(
            new IncomingServiceBusMessage(
                args.Message.MessageId,
                args.Message.Subject,
                args.Message.Body.ToString()),
            cancellationToken => args.CompleteMessageAsync(args.Message, cancellationToken),
            cancellationToken => args.AbandonMessageAsync(args.Message, cancellationToken: cancellationToken),
            args.CancellationToken);

        processor.ProcessErrorAsync += args =>
        {
            logger.LogError(args.Exception, "Azure Service Bus receiver encountered an error in {ErrorSource}.", args.ErrorSource);
            return Task.CompletedTask;
        };

        logger.LogInformation("Service Bus receiver worker started.");
        await processor.StartProcessingAsync(stoppingToken);

        try
        {
            await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // Normal hosted-service shutdown.
        }
        finally
        {
            await processor.StopProcessingAsync(CancellationToken.None);
        }
    }
}
