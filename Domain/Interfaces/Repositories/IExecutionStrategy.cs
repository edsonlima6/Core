using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IExecutionStrategy
    {
        Task ExecuteAsync(Func<Task> operation, CancellationToken cancellationToken = default);
        Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken = default);
    }
}

