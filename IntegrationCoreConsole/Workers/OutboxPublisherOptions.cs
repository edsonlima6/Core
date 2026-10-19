namespace IntegrationCoreConsole.Workers;

public sealed class OutboxPublisherOptions
{
    public bool Enabled { get; set; }
    public int BatchSize { get; set; } = 10;
    public int PollIntervalSeconds { get; set; } = 5;
}
