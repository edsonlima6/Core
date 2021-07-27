using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreEF.Db
{
    public class UnitOfWorkEF : IUnitOfWorkCore
    {
        public IDbContextTransaction transactionEF { get; set; }
        public ContextBD contextBD { get; set; }

        public SqlTransaction transactionInterface { get; private set; }

        SqlTransaction IUnitOfWorkCore.transaction => throw new NotImplementedException();

        public SqlConnection connection => throw new NotImplementedException();

        public UnitOfWorkEF(ContextBD _contextBD)
        {
            contextBD = _contextBD;
            transactionEF = contextBD.Database.BeginTransaction();
        }
        public void Commit()
        {
            try
            {
                transactionEF.Commit();
            }
            catch (Exception)
            {
                Rollback();
            }
        }

        public void Dispose()
        {
            transactionEF.Dispose();
            contextBD.Dispose();
        }

        public void Rollback()
        {
            transactionEF.Rollback();
        }
    }
}
