using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreDapper
{
    public class RepositoryBase : IDisposable
    {
        private SqlConnectionStringBuilder connectionStringBuilder { get; }
        public SqlConnection connection { get; private set; }
        public SqlTransaction transaction { get; set; }

        public RepositoryBase()
        {
            connectionStringBuilder = new SqlConnectionStringBuilder(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoreBase;Integrated Security=True;");
        }




        public void Dispose()
        {
            transaction?.Dispose();
            connection?.Dispose();
            connection?.Close();
            connection = null;
            transaction = null;
        }

        

    }
}
