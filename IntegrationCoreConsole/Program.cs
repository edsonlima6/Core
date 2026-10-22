
using Azure.Messaging.ServiceBus;
using Infra.IoC;
using IntegrationCoreConsole.Workers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IntegrationCoreConsole;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(logging => logging.AddConsole());
        var logger = loggerFactory.CreateLogger("IntegrationCoreConsole");

        try
        {
            logger.LogInformation("Starting IntegrationCoreConsole on {OperatingSystem}.", Environment.OSVersion);

            var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
            {
                Args = args,
                ContentRootPath = AppContext.BaseDirectory
            });
            var configuration = builder.Configuration;
            logger.LogInformation("Hosting environment: {Environment}.", builder.Environment.EnvironmentName);
            var publishEnabled = configuration.GetValue<bool>("OutboxPublisher:Enabled");
            var receiveEnabled = configuration.GetValue<bool>("OutboxReceiver:Enabled");

            logger.LogInformation("Worker configuration loaded. Outbox publisher enabled: {PublisherEnabled}; Service Bus receiver enabled: {ReceiverEnabled}.",
                publishEnabled, receiveEnabled);

            if (!publishEnabled && !receiveEnabled)
            {
                logger.LogWarning("No workers are enabled. IntegrationCoreConsole will exit.");
                return;
            }

            logger.LogInformation("IntegrationCoreConsole starting with the following configuration: Outbox publisher enabled: {PublisherEnabled}; Service Bus receiver enabled: {ReceiverEnabled}.",
                publishEnabled, receiveEnabled);

            if (publishEnabled)
            {
                var connectionStringName = OperatingSystem.IsLinux()
                    ? "connectionStringLinux"
                    : "connectionStringWin";
                var databaseConnectionString = configuration.GetConnectionString(connectionStringName);
                if (string.IsNullOrWhiteSpace(databaseConnectionString))
                    throw new InvalidOperationException($"Database connection string 'ConnectionStrings:{connectionStringName}' is required when the outbox publisher is enabled.");

                builder.Services.AddConfigureServices(databaseConnectionString);

                if (configuration.GetValue<int>("OutboxPublisher:BatchSize", 10) < 1 ||
                    configuration.GetValue<int>("OutboxPublisher:PollIntervalSeconds", 5) < 1)
                    throw new InvalidOperationException("Outbox publisher batch size and poll interval must be greater than zero.");
            }

            if (publishEnabled || receiveEnabled)
            {
                var connectionString = configuration["AzureServiceBus:skynet-policy-subscription-conn"];
                logger.LogInformation("Using Azure Service Bus connection string from configuration. skynet-policy-subscription-conn: {ConnectionString}.", connectionString);
                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new InvalidOperationException("Azure Service Bus connection string is required when a messaging worker is enabled. Set 'AzureServiceBus:skynet-policy-subscription-conn'.");

                builder.Services.AddSingleton(_ => new ServiceBusClient(connectionString));
            }

            if (publishEnabled)
            {
                var topicName = RequireSetting(configuration["AzureServiceBus:TopicName"], "AzureServiceBus:TopicName");
                builder.Services.Configure<OutboxPublisherOptions>(configuration.GetSection("OutboxPublisher"));
                builder.Services.AddSingleton(provider => provider.GetRequiredService<ServiceBusClient>().CreateSender(topicName));
                builder.Services.AddSingleton<IServiceBusMessageSender, AzureServiceBusMessageSender>();
                builder.Services.AddScoped<OutboxMessagePublisher>();
                builder.Services.AddHostedService<OutboxPublisherWorker>();
                logger.LogInformation("Outbox publisher registered for topic {TopicName}.", topicName);
            }

            if (receiveEnabled)
            {
                var topicName = RequireSetting(configuration["AzureServiceBus:TopicName"], "AzureServiceBus:TopicName");
                var subscriptionName = RequireSetting(configuration["AzureServiceBus:SubscriptionName"], "AzureServiceBus:SubscriptionName");
                builder.Services.AddSingleton(provider => provider.GetRequiredService<ServiceBusClient>()
                    .CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions
                    {
                        AutoCompleteMessages = false,
                        MaxConcurrentCalls = 1
                    }));
                builder.Services.AddSingleton<ServiceBusMessageProcessor>();
                builder.Services.AddSingleton<IIncomingServiceBusMessageHandler, ConsoleServiceBusMessageHandler>();
                builder.Services.AddHostedService<ServiceBusMessageReceiverWorker>();
                logger.LogInformation("Service Bus receiver registered for topic {TopicName}, subscription {SubscriptionName}.", topicName, subscriptionName);
            }

            var host = builder.Build();
            logger.LogInformation("IntegrationCoreConsole host built; starting background workers.");
            await host.RunAsync();
            logger.LogInformation("IntegrationCoreConsole host stopped normally.");
        }
        catch (Exception exception)
        {
            logger.LogCritical(exception, "IntegrationCoreConsole terminated due to an unhandled exception.");
            throw;
        }
    }

    private static string RequireSetting(string value, string settingName) =>
        string.IsNullOrWhiteSpace(value)
            ? throw new InvalidOperationException($"Configuration setting '{settingName}' is required.")
            : value;
}


