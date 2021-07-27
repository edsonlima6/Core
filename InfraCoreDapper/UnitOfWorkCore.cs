using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreDapper
{
    public class UnitOfWorkCore : IUnitOfWorkCore, IDisposable
    {

        protected string connectionString { get; private set; }
        public SqlTransaction transaction { get; private set; }

        public SqlConnection connection { get; private set; }

        public UnitOfWorkCore()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                     .AddJsonFile("Appsetting.json")
                                                     .Build();

            connectionString = config.GetConnectionString("connectionStringWin");
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

        void IUnitOfWorkCore.Commit()
        {
            Commit();
        }

        void IUnitOfWorkCore.Rollback()
        {
            Rollback();
        }

        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
