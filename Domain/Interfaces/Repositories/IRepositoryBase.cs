using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryBase
    {
        Task<long> Insert<T>(T obj) where T : class;
        Task<long> Update();
        Task<long> GetById();
        Task<long> GetAll();
        Task<long> Delete();
        //void Commit();
        //void Dispose();
    }

    public interface IUnitOfWork : IDisposable
    {
        bool Disposed { get; }
        Guid Id { get; }
        SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
