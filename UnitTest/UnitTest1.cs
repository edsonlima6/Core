using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.IoC;
using InfraCoreDapper;
using InfraCoreEF.Db;
using InfraCoreSQLite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        static ServiceCollection serviceCollection;
        ServiceProvider serviceProvider { get { return serviceCollection.BuildServiceProvider(); } }
        public UnitTest1()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddConfigureServices("SQLite");
        }

        //[TestMethod]
        //public void TestUnitOfWork()
        //{
        //    try
        //    {
        //        var unit = serviceProvider.GetService<IUnitOfWorkCore>();
        //        using (unit)
        //        {
        //            var baseRepo = new RepositoryBase(unit);
        //            var user = new User(name: "DAPPER", lastName: "Feitosa", email: "edson6@gmail.com") { CreatedON = DateTime.Now };


        //            baseRepo.Insert<User>(user);

        //            unit.Commit();
        //        }
                
                
        //        //Assert.IsTrue(idUser > 0);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }
        //}

        [TestMethod]
        public void TestSaveUser()
        {
            try
            {
                int idUser = 0;
                List<User> usersCreated = new List<User>();

                var dbContext = serviceProvider.GetRequiredService<SQLiteDbContext>();
                using (dbContext)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var user = new User(name: "Edson", lastName: "Feitosa", email: "edson6@gmail.com") { CreatedON = DateTime.Now };
                        dbContext.Users.Add(user);
                    }
                    idUser = dbContext.SaveChanges();

                    usersCreated = dbContext.Users.ToList();

                }

                Assert.IsTrue(idUser > 0);
                Assert.IsTrue(usersCreated.Count > 0);
            }
            catch (Exception ex)
            {
               Assert.Fail(ex.Message);
            }
        }
    
    }
}
