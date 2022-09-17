using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using ProductsWebAPI.Controllers;
using ProductsWebAPI.Helpers;
using ProductsWebAPI.Models;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductsWebAPI.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        private AccountController _accountController;

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();

            mockConfig
                .Setup(c => c.GenerateJwtToken(It.IsAny<User>()))
                .Returns("123");

            Mock<IAccountService<User, RegisterModel>> mockAccountService = new Mock<IAccountService<User, RegisterModel>>();
            
            mockAccountService
                .Setup(s => s.Add(It.IsAny<RegisterModel>()))
                .Returns(new User()
                {
                    Login = "user", Password = "123".GetHashCode(), Role = Role.User
                });
            
            _accountController = new AccountController(mockAccountService.Object, mockConfig.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _accountController = null;
        }

        [TestMethod]
        public void Register_ValidModel_OkStatus()
        {
            // Arrange

            var registerModel = new RegisterModel() { Login = "user", Password = "123", PasswordConfirm = "123" };

            // Act

            var actualResult = _accountController.Register(registerModel);

            // Assert

            Assert.IsTrue(actualResult is OkObjectResult);
        }
    }
}
