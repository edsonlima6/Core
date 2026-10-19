using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraCoreEF.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InfraCoreEF.Repositories
{
    public class OutboxMessageRepository(ContextBD contextBD) : RepositoryBase<OutboxMessage>(contextBD), IOutboxMessageRepository
    {
        public async Task AddAsync(OutboxMessage message)
        {
            await InsertAsync(message);
        }

        public async Task<IReadOnlyList<OutboxMessage>> GetPendingAsync(int batchSize, CancellationToken cancellationToken = default)
        {
            return await Db.OutboxMessages
                .Where(message => message.ProcessedAt == null)
                .OrderBy(message => message.CreatedAt)
                .Take(batchSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task MarkProcessedAsync(int id, CancellationToken cancellationToken = default)
        {
            var message = await Db.OutboxMessages
                .FirstOrDefaultAsync(outboxMessage => outboxMessage.Id == id, cancellationToken);

            if (message == null)
                return;

            message.ProcessedAt = System.DateTime.UtcNow;
            await Db.SaveChangesAsync(cancellationToken);
        }
    }
}
