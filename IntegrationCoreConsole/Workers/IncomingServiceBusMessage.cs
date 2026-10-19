namespace IntegrationCoreConsole.Workers;

public sealed record IncomingServiceBusMessage(string MessageId, string Subject, string Body);
