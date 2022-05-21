using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.IoC;
using InfraCoreDapper;
using InfraCoreEF.Db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class TestUserUnit
    {
        static ServiceCollection serviceCollection;
        ServiceProvider serviceProvider { get { return serviceCollection.BuildServiceProvider(); } }
        public TestUserUnit()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddConfigureServices("SQL");
        }

        [TestMethod]
        public void TestCreateUser()
        
        {
            try
            {
                long row = 0;
                var unit = serviceProvider.GetService<IUnitOfWorkCore>();
                using (unit)
                {
                    var baseRepo = new RepositoryBase(unit);
                    var user = new User(name: "Edson", lastName: "Feitosa", email: "edson6@gmail.com") { CreatedON = DateTime.Now };
                    row = baseRepo.Insert<User>(user).Result;

                    unit.Commit();
                }


                Assert.IsTrue(row > 0);
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestCreateValidUser()
        {
            try
            {
                var user = new User(name: "Edson", lastName: "Feitosa", email: "edson6@gmail.com") { CreatedON = DateTime.Now };
                var validResponse  = user.IsValid();

                Assert.IsTrue(validResponse.valid, validResponse.message);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
