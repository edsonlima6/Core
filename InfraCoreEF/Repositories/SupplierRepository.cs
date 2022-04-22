using Domain.Entities;
using InfraCoreEF.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreEF.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>
    {
        public SupplierRepository(ContextBD contextBD) : base(contextBD)
        {

        }



    }
}
