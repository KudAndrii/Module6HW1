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

            mockConfig.SetupGet(s => s[It.Is<string>(str => str == "Jwt:Key")]).Returns("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx");
            mockConfig.SetupGet(s => s[It.Is<string>(str => str == "Jwt:Issuer")]).Returns("JWTAuthenticationServer");
            mockConfig.SetupGet(s => s[It.Is<string>(str => str == "Jwt:Audience")]).Returns("JWTServicePostmanClient");
            mockConfig.SetupGet(s => s[It.Is<string>(str => str == "Jwt:Subject")]).Returns("JWTServiceAccessToken");

            Mock<IAccountService<User, RegisterModel>> mockAccountService = new Mock<IAccountService<User, RegisterModel>>();
            
            mockAccountService
                .Setup(s => s.Add(It.IsAny<RegisterModel>()))
                .Returns(new User()
                {
                    Login = "user", Password = "123".GetHashCode(), Role = Role.User
                });

            mockAccountService
                .Setup(s => s.GetAll())
                .Returns(new List<User>()
                {
                    new User()
                    {
                    Login = "user", Password = "123".GetHashCode(), Role = Role.User
                    }
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

        [TestMethod]
        public void Register_NotValidModel_BadStatus()
        {
            // Arrange

            var registerModel = new RegisterModel() { Login = "user", Password = "123", PasswordConfirm = "123" };

            // Act

            var actualResult = _accountController.Register(registerModel);

            // Assert

            Assert.IsTrue(actualResult is BadRequestObjectResult);
        }

        [TestMethod]
        public void Login_ValidLogin_OkStatus()
        {
            // Arrange

            var loginModel = new LoginModel() { Login = "user", Password = "123" };

            // Act

            var actualResult = _accountController.Login(loginModel);

            // Assert

            Assert.IsTrue(actualResult is OkObjectResult);
        }

        [TestMethod]
        public void Login_NotValidLogin_BadStatus()
        {
            // Arrange

            var loginModel = new LoginModel() { Login = "user2", Password = "123" };

            // Act

            var actualResult = _accountController.Login(loginModel);

            // Assert

            Assert.IsTrue(actualResult is BadRequestObjectResult);
        }
    }
}
