using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreEF.Db
{
    public class UnitOfWorkEF : IUnitOfWorkCore
    {
        public IDbContextTransaction transaction { get; set; }
        public ContextBD contextBD { get; set; }
        public UnitOfWorkEF(ContextBD _contextBD)
        {
            contextBD = _contextBD;
            transaction = contextBD.Database.BeginTransaction();
        }
        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
            }
        }

        public void Dispose()
        {
            transaction.Dispose();
            contextBD.Dispose();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}
