using System.Threading;
using System.Threading.Tasks;

namespace IntegrationCoreConsole.Workers;

public interface IIncomingServiceBusMessageHandler
{
    Task HandleAsync(IncomingServiceBusMessage message, CancellationToken cancellationToken);
}
