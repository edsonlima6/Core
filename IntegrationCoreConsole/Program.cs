using Dapper;
using Dapper.Contrib.Extensions;
using Domain.Context;
using Domain.Entities;
using InfraCoreDapper;
using System;

namespace IntegrationCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var conection = new RepositoryBase();
            UserAccount user = new UserAccount { Name = "Edson" };

            try
            {
                using (var con = new DalSession())
                {
                    var _UnitOfWork = con.UnitOfWork;
                    // _UnitOfWork.Begin();
                    _UnitOfWork.Connection.Open();
                   // var tran = _UnitOfWork.Connection.BeginTransaction();

                    try
                    {
                        _UnitOfWork.Connection.Insert<UserAccount>(user);

                        _UnitOfWork.Commit();
                    }
                    catch (Exception ex)
                    {
                        _UnitOfWork.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            


        }
    }
}
