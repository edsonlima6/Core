using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreDapper
{
    public class UnitOfWork : IUnitOfWork
    {
        internal UnitOfWork(SqlConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;
        }

        bool _disposed;
        private SqlConnection _connection;
        SqlTransaction _transaction = null;
        Guid _id = Guid.Empty;

        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        SqlTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }

        Guid IUnitOfWork.Id
        {
            get { return _id; }
        }
        bool IUnitOfWork.Disposed
        {
            get { return _disposed; }
        }

        public void Begin()
        {
            _disposed = false;
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }


        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            _disposed = true;
        }
    }
}
