
using Azure.Messaging.ServiceBus;
using Infra.IoC;
using IntegrationCoreConsole.Workers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace IntegrationCoreConsole;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            Args = args,
            ContentRootPath = AppContext.BaseDirectory
        });
        var configuration = builder.Configuration;
        var publishEnabled = configuration.GetValue<bool>("OutboxPublisher:Enabled");
        var receiveEnabled = configuration.GetValue<bool>("OutboxReceiver:Enabled");

        if (!publishEnabled && !receiveEnabled)
            return;

        if (publishEnabled)
        {
            var connectionStringName = OperatingSystem.IsLinux()
                ? "connectionStringLinux"
                : "connectionStringWin";
            builder.Services.AddConfigureServices(
                configuration.GetConnectionString(connectionStringName) ?? string.Empty);

            if (configuration.GetValue<int>("OutboxPublisher:BatchSize", 10) < 1 ||
                configuration.GetValue<int>("OutboxPublisher:PollIntervalSeconds", 5) < 1)
                throw new InvalidOperationException("Outbox publisher batch size and poll interval must be greater than zero.");
        }

        if (publishEnabled || receiveEnabled)
        {
            var connectionString = configuration["AzureServiceBus:skynet-policy-subscription-conn"];
            if (string.IsNullOrWhiteSpace(connectionString))  
                throw new InvalidOperationException("Azure Service Bus connection string is required when a messaging worker is enabled.");

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
        }

        await builder.Build().RunAsync();
    }

    private static string RequireSetting(string value, string settingName) =>
        string.IsNullOrWhiteSpace(value)
            ? throw new InvalidOperationException($"Configuration setting '{settingName}' is required.")
            : value;
}


