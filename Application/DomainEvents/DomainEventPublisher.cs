using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEvents
{
    public class DomainEventPublisher : IDomainEventPublisher
    {
        private readonly IServiceProvider serviceProvider;

        public DomainEventPublisher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent
        {
            var handlers = serviceProvider.GetService(typeof(IEnumerable<IDomainEventHandler<TEvent>>))
                as IEnumerable<IDomainEventHandler<TEvent>>;

            if (handlers == null)
                return;

            foreach (var handler in handlers)
            {
                await handler.HandleAsync(domainEvent, cancellationToken);
            }
        }
    }
}
