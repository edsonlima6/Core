using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InfraCoreEF.Db
{
    public class UnitOfWorkEF : InfraCoreEF.Db.IUnitOfWork, Domain.Interfaces.Repositories.IUnitOfWork
    {
        public IDbContextTransaction transactionEF { get; set; }
        public ContextBD contextBD { get; set; }

        public UnitOfWorkEF(ContextBD _contextBD)
        {
            contextBD = _contextBD ?? throw new ArgumentNullException(nameof(_contextBD));
            // Do not start a transaction immediately; start when requested
            transactionEF = null;
        }

        // Synchronous compatibility methods (preserve existing behavior)
        public void Commit()
        {
            try
            {
                transactionEF?.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                transactionEF?.Dispose();
                transactionEF = null;
            }
        }

        public void Rollback()
        {
            try
            {
                transactionEF?.Rollback();
            }
            finally
            {
                transactionEF?.Dispose();
                transactionEF = null;
            }
        }

        public void Dispose()
        {
            transactionEF?.Dispose();
            contextBD?.Dispose();
        }

        // Async recommended API
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (transactionEF != null)
                return transactionEF;

            transactionEF = await contextBD.Database.BeginTransactionAsync();
            return transactionEF;
        }

        public Domain.Interfaces.Repositories.IExecutionStrategy CreateExecutionStrategy() =>
            new EfExecutionStrategyAdapter(contextBD.Database.CreateExecutionStrategy());

        async Task Domain.Interfaces.Repositories.IUnitOfWork.BeginTransactionAsync(CancellationToken cancellationToken)
        {
            if (transactionEF != null)
                return;

            transactionEF = await contextBD.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (transactionEF == null)
                return;

            try
            {
                await contextBD.SaveChangesAsync(cancellationToken);
                await transactionEF.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (transactionEF != null)
                {
                    await transactionEF.DisposeAsync();
                    transactionEF = null;
                }
            }
        }

        public async Task CommitAsync()
        {
            if (transactionEF == null)
                return;

            try
            {
                await contextBD.SaveChangesAsync();
                await transactionEF.CommitAsync();
            }
            catch (Exception)
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                await transactionEF.DisposeAsync();
                transactionEF = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (transactionEF == null)
                return;

            try
            {
                await transactionEF.RollbackAsync();
            }
            finally
            {
                await transactionEF.DisposeAsync();
                transactionEF = null;
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            if (transactionEF == null)
                return;

            try
            {
                await transactionEF.RollbackAsync(cancellationToken);
            }
            finally
            {
                await transactionEF.DisposeAsync();
                transactionEF = null;
            }
        }

        public Task ExecuteExecutionStrategyAsync(Func<Task> operation, CancellationToken cancellationToken = default) =>
            CreateExecutionStrategy().ExecuteAsync(operation, cancellationToken);

        public Task<TResult> ExecuteExecutionStrategyAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken = default) =>
            CreateExecutionStrategy().ExecuteAsync(operation, cancellationToken);

    }
}
