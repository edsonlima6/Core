using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace InfraCoreEF.Db
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
