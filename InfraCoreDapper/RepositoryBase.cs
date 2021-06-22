using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreDapper
{
    public class RepositoryBase : IRepositoryBase
    {
        //private SqlConnectionStringBuilder connectionStringBuilder { get; }
        //public SqlConnection connection { get; private set; }
        public SqlTransaction transaction { get; set; }

        public string connectionString { get; set; }

        public RepositoryBase(UnitOfWorkCore unitOfWorkCore)
        {
            transaction = unitOfWorkCore.transaction;
        }


        //public void OpenDatabase()
        //{
        //    connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    transaction = connection.BeginTransaction();
        //}

        //public void Dispose()
        //{
        //    transaction?.Dispose();
        //    connection?.Dispose();
        //    connection?.Close();
        //    connection = null;
        //    transaction = null;
        //    GC.SuppressFinalize(this);
        //}

        //public void Commit()
        //{
        //    try
        //    {
        //        if (connection.State == System.Data.ConnectionState.Open)
        //            transaction.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        Rollback();
        //    }
        //}

        //public void Rollback()
        //{
        //    if (connection.State == System.Data.ConnectionState.Open)
        //        transaction.Rollback();
        //}

        public Task<long> Insert()
        {
            throw new NotImplementedException();
        }

        public Task<long> Update()
        {
            throw new NotImplementedException();
        }

        public Task<long> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<long> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<long> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
