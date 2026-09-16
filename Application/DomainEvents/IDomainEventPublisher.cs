using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEvents
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent;
    }
}
