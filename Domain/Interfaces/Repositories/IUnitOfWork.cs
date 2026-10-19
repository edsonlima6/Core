using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IExecutionStrategy CreateExecutionStrategy();
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task ExecuteExecutionStrategyAsync(Func<Task> operation, CancellationToken cancellationToken = default);
        Task<TResult> ExecuteExecutionStrategyAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken = default);
        void Commit();
        void Rollback();
    }
}

