using System.Threading;
using System.Threading.Tasks;

namespace IntegrationCoreConsole.Workers;

public interface IServiceBusMessageSender
{
    Task SendAsync(string messageId, string subject, string body, CancellationToken cancellationToken);
}
