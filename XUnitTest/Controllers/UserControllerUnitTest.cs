using Application.Handles;
using AutoFixture;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentAssertions;
using InfraCoreEF.Db;
using InfraCoreEF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using SkyNetApiCore.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Controllers
{
    public class UserControllerUnitTest
    {
        protected Fixture specimenBuilders { get; set; }

        #region Application

        protected Mock<UserHandler> UserHandlerMock { get; set; }

        #endregion

        #region InfraStructureMock
        protected Mock<ContextBD>? ContextBDMock  { get; set; }

        protected Mock<IUserRepository>? IUserRepositoryMock { get; set; }

        #endregion InfraStructureMock

        #region EntitiesDB
        public List<User> UsersFromDbMock { get{ return specimenBuilders.Build<User>().CreateMany().ToList(); } }

        #endregion EntitiesDB
        public UserControllerUnitTest()
        {
            specimenBuilders = new Fixture();
            SetupContextDB();
        }

        private void SetupContextDB()
        {
            ContextBDMock = new Mock<ContextBD>();
            ContextBDMock.Setup<DbSet<User>>(x => x.Users).ReturnsDbSet(UsersFromDbMock);
            IUserRepositoryMock = new Mock<IUserRepository>();

            IUserRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(UsersFromDbMock.AsQueryable());
            UserHandlerMock = new Mock<UserHandler>(IUserRepositoryMock.Object);


        }

        [Fact]
        public async void UserControllerCheck()
        {
            var userHandlerMocked = UserHandlerMock;
            var loggetMocked = new Mock<ILogger<UserController>>();
            UserController _userController = new UserController(loggetMocked.Object, userHandlerMocked.Object);

            var result = await _userController.GetUsers();

            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(0);
            result.Should().Subject.Should().BeOfType<EnumerableQuery<User>>();
        }


        [Fact]
        public void ContextDB_GetUsers_Test()
        {
            var contextDB = ContextBDMock;

            var expectedResult = contextDB?.Object.Users.ToList();

            expectedResult.Should().NotBeNullOrEmpty();
            expectedResult.Should().HaveCountGreaterThan(0);
            expectedResult.Should().NotBeEmpty();
        }

        [Fact]
        public async void UserHandler_GetUserMethod_Test()
        {
            var userHandlerMocked = UserHandlerMock;

            var result = await userHandlerMocked.Object.GetAllAsync();

            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(0);
            result.Should().Subject.Should().BeOfType<EnumerableQuery<User>>();
        }

        [Fact]
        public async void UserRepository_GetAllAsync_Test()
        {
            var contextDB = ContextBDMock;
            var userRepositoryMocked = new Mock<UserRepository>(contextDB?.Object);

            var result = await userRepositoryMocked.Object.GetAllAsync();

            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(0);
            result.Should().Subject.Should().BeOfType<EnumerableQuery<User>>();
        }

    }
}
