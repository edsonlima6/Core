using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraCoreEF.Db;

namespace InfraCoreEF.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ContextBD contextBD) : base(contextBD)
        {
        }
    }
}
