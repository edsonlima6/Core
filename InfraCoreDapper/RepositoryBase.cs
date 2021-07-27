using Dapper;
using Dapper.Contrib.Extensions;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreDapper
{
    public class RepositoryBase : IRepositoryBase, IDisposable
    {
        //private SqlConnectionStringBuilder connectionStringBuilder { get; }
        //public SqlConnection connection { get; private set; }
        protected SqlTransaction transaction { get; set; }
        protected SqlConnection connection { get; set; }


        public string connectionString { get; set; }

        IUnitOfWorkCore unitOfWorkCore;

        public RepositoryBase(IUnitOfWorkCore _unitOfWorkCore)
        {
            unitOfWorkCore = _unitOfWorkCore;
            connection = unitOfWorkCore.connection;
            transaction = unitOfWorkCore.transaction;
        }

        private T GetTransaction<T>() 
        {
            string obj = "";
            return (T)Convert.ChangeType(obj, typeof(T));
        }



        public Task<long> Insert<T>(T obj) where T : class
        {
            try
            {
                var affectedRows = connection.Insert<T>(obj, transaction: transaction);

                return Task.FromResult(long.MaxValue);
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public void Dispose()
        {
            transaction.Dispose();
        }
    }
}
