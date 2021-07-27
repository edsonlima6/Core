using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.IoC;
using InfraCoreDapper;
using InfraCoreEF.Db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            serviceCollection.AddConfigureServices();
        }

        [TestMethod]
        public void TestUnitOfWork()
        {
            try
            {
                var unit = serviceProvider.GetService<IUnitOfWorkCore>();
                using (unit)
                {
                    var baseRepo = new RepositoryBase(unit);
                    var blog = new Blog() { Name = "File 11", Url = "http://" };

                    baseRepo.Insert<Blog>(blog);

                    unit.Commit();
                }

            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestSaveUser()
        {
            try
            {
                var dbContext = serviceProvider.GetRequiredService<ContextBD>();
                using (dbContext)
                {
                    var user = new User(name: "Edson", lastName:"Feitosa", email:"edsonlima6@gmail.com") { CreatedON = DateTime.Now };
                    dbContext.Users.Add(user);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    
    }
}
