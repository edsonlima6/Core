using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class DalSession : IDisposable
    {
		SqlConnection _connection = null;
		readonly UnitOfWork _unitOfWork = null;
        private readonly SqlConnectionStringBuilder connectionStringBuilder;
        private readonly string _connectionString;
		private bool _disposed;

		public DalSession()
		{
			connectionStringBuilder = new SqlConnectionStringBuilder(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoreBase;Integrated Security=True;");
			_connectionString = connectionStringBuilder.ConnectionString; //ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
			_connection = new SqlConnection(_connectionString);
			_connection.Open();
			_unitOfWork = new UnitOfWork(_connection);
		}

		public UnitOfWork UnitOfWork
		{
			get { return _unitOfWork; }
		}

		private void dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				_unitOfWork.Dispose();

				if (_connection != null)
				{
					_connection.Dispose();
					_connection = null;
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
