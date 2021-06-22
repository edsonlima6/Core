using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreDapper
{
    public class UnitOfWorkCore : IUnitOfWorkCore
    {
        IRepositoryBase repositoryBase { get; set; }

        private SqlConnection connection { get; set; }
        public SqlTransaction transaction { get; set; }

        public string connectionString { get; set; }
        public UnitOfWorkCore(string _connectionString)
        {
            connectionString = _connectionString;
            OpenTransaction();
        }

        private void OpenTransaction()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
            }
        }

        public void Dispose()
        {

            transaction?.Dispose();
            connection?.Dispose();
            connection?.Close();
            connection = null;
            transaction = null;
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                transaction.Rollback();
        }
    }
}
