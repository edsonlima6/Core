using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InfraCoreEF.Db
{
    public class EfExecutionStrategyAdapter : IExecutionStrategy
    {
        private readonly Microsoft.EntityFrameworkCore.Storage.IExecutionStrategy _strategy;

        public EfExecutionStrategyAdapter(Microsoft.EntityFrameworkCore.Storage.IExecutionStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public Task ExecuteAsync(Func<Task> operation, CancellationToken cancellationToken = default)
        {
            return _strategy.ExecuteAsync(ct => operation(), cancellationToken);
        }

        public Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken = default)
        {
            return _strategy.ExecuteAsync(ct => operation(), cancellationToken);
        }
    }
}

