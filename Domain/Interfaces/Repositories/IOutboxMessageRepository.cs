using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IOutboxMessageRepository
    {
        Task AddAsync(OutboxMessage message);
        Task<IReadOnlyList<OutboxMessage>> GetPendingAsync(int batchSize, CancellationToken cancellationToken = default);
        Task MarkProcessedAsync(int id, CancellationToken cancellationToken = default);
    }
}
