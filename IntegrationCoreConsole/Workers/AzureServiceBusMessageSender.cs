using Azure.Messaging.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationCoreConsole.Workers;

public sealed class AzureServiceBusMessageSender(ServiceBusSender sender) : IServiceBusMessageSender
{
    public Task SendAsync(string messageId, string subject, string body, CancellationToken cancellationToken)
    {
        var message = new ServiceBusMessage(body)
        {
            MessageId = messageId,
            ContentType = "application/json",
            Subject = subject
        };

        return sender.SendMessageAsync(message, cancellationToken);
    }
}
