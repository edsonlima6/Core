using Dapper;
using Dapper.Contrib.Extensions;
using Domain.Context;
using Domain.Entities;
using InfraCoreDapper;
using InfraCoreEF.Db;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace IntegrationCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var directory = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder().SetBasePath(directory)
                                                   .AddJsonFile("Appsetting.json")
                                                   .Build();

            var con = config.GetConnectionString("connectionStringWin");

            
           

            ContextBD contextBD = new ContextBD();
            UserAccount user = new UserAccount { Name = "Edson" };

            try
            {

                using (var unitOfWork = new UnitOfWorkCore(con))
                {
                    var repoBase = new RepositoryBase(unitOfWork); //UnitOfWorkEF



                }

                using (var uniOfWork = new UnitOfWorkEF(contextBD))
                {
                    try
                    {
                        contextBD.Blogs.Add(new Blog() { Name = "File 1", Url = "http://" });
                        contextBD.SaveChanges();

                        uniOfWork.Commit();
                    }
                    catch (Exception ex)
                    {
                        uniOfWork.Rollback();
                        throw;
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


