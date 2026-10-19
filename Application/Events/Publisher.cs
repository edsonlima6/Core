using Application.DTOs;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Events
{
    public class Publisher(ServiceBusSender serviceBusSender, ILogger<Publisher> logger) : IPublisher
    {
        private readonly ServiceBusSender _serviceBusSender = serviceBusSender ?? throw new ArgumentNullException(nameof(serviceBusSender));
        private readonly ILogger<Publisher> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task PublishAsync(CreateUserDto message, CancellationToken cancellationToken = default)
        {
            try
            {
                ServiceBusMessage serviceBusMessage = new ServiceBusMessage
                {
                    Body = new BinaryData(message.Name),
                    MessageId = Guid.NewGuid().ToString(),
                    ContentType = "application/json",
                    Subject = "NewChange"
                };

                await _serviceBusSender.SendMessageAsync(serviceBusMessage, cancellationToken);
                _logger.LogInformation("Message published to Azure Service Bus: {Message}", message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing message to Azure Service Bus: {Message}", message);
                throw;
            }
        }
    }
}
