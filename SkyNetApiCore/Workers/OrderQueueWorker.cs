using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SkyNetApiCore.Workers
{
    public class OrderQueueWorker : BackgroundService
    {
        private readonly ILogger<OrderQueueWorker> logger;
        private readonly RabbitMqOptions options;
        private IConnection connection;
        private IChannel channel;

        public OrderQueueWorker(IOptions<RabbitMqOptions> options, ILogger<OrderQueueWorker> logger)
        {
            this.options = options.Value;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await StartConsumingAsync(stoppingToken);

                    logger.LogInformation("RabbitMQ order queue listener started for queue {QueueName}", options.QueueName);
                    await Task.Delay(Timeout.Infinite, stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "RabbitMQ order queue listener failed. Retrying in 5 seconds");
                    CloseRabbitMqConnection();
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }
        }

        private async Task StartConsumingAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = options.HostName,
                Port = options.Port,
                UserName = options.UserName,
                Password = options.Password,
                VirtualHost = options.VirtualHost
            };

            connection = await factory.CreateConnectionAsync(cancellationToken);
            channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);
            await channel.QueueDeclareAsync(
                queue: options.QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: cancellationToken);
            await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: options.PrefetchCount, global: false, cancellationToken: cancellationToken);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += ProcessOrderMessageAsync;

            await channel.BasicConsumeAsync(
                queue: options.QueueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: cancellationToken);
        }

        private async Task ProcessOrderMessageAsync(object sender, BasicDeliverEventArgs eventArgs)
        {
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

            try
            {
                await ProcessOrderAsync(message);
                await channel.BasicAckAsync(eventArgs.DeliveryTag, multiple: false);
            }
            catch (JsonException ex)
            {
                logger.LogError(ex, "Invalid order message received from queue {QueueName}: {Message}", options.QueueName, message);
                await channel.BasicRejectAsync(eventArgs.DeliveryTag, requeue: false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing order message from queue {QueueName}", options.QueueName);
                await channel.BasicNackAsync(eventArgs.DeliveryTag, multiple: false, requeue: true);
            }
        }

        private Task ProcessOrderAsync(string message)
        {
            using var order = JsonDocument.Parse(message);

            logger.LogInformation(
                "Processing order message from queue {QueueName}: {Order}",
                options.QueueName,
                order.RootElement.GetRawText());

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("RabbitMQ order queue listener is stopping");

            CloseRabbitMqConnection();

            return base.StopAsync(cancellationToken);
        }

        private void CloseRabbitMqConnection()
        {
            channel?.Dispose();
            connection?.Dispose();
            channel = null;
            connection = null;
        }

        public override void Dispose()
        {
            CloseRabbitMqConnection();
            base.Dispose();
        }
    }
}
