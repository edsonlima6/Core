using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkCore : IDisposable
    {
        SqlTransaction transaction { get; }
        SqlConnection connection { get; }
        void Commit();
        void Rollback();
        new void Dispose();
    }
}
