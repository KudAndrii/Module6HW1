
namespace ProductsWebAPI.Tests
{
    using Core.Entities;
    using Core.Enums;
    using Infrastructure.Services;
    using ProductsWebAPI.Models;

    [TestClass]
    public class AccountServiceTests
    {
        private AccountService _accountService;

        [TestInitialize]
        public void TestInitialize()
        {
            _accountService = new AccountService();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _accountService = null;
        }

        [TestMethod]
        public void Add_ValidUserModel_UserModel()
        {
            // Arrange

            RegisterModel userModel = new RegisterModel()
            {
                Login = "user",
                Password = "123",
                PasswordConfirm = "123"
            };

            // Act

            var actualResult = _accountService.Add(userModel);

            // Assert

            Assert.IsTrue(actualResult.Role == Role.User);
        }

        [TestMethod]
        public void Add_ValidAdminModel_AdminModel()
        {
            // Arrange

            RegisterModel superUserModel = new RegisterModel()
            {
                Login = "suUser",
                Password = "123",
                PasswordConfirm = "123"
            };

            // Act

            var actualResult = _accountService.Add(superUserModel);

            // Assert

            Assert.IsTrue(actualResult.Role == Role.Admin);
        }

        [TestMethod]
        public void GetById_ValidModel_SameModel()
        {
            // Arrange

            var expectedResult = new User()
            {
                Login = "user",
                Password = "123".GetHashCode(),
                Role = Role.User
            };

            RegisterModel userModel = new RegisterModel()
            {
                Login = "user",
                Password = "123",
                PasswordConfirm = "123"
            };
            _accountService.Add(userModel);

            // Act

            var actualResult = _accountService.GetById(1);

            // Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_NotExistingModel_Null()
        {
            // Arrange

            // Act

            var actualResult = _accountService.GetById(1);

            // Assert

            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void GetAll_ValidModels_SameModels()
        {
            // Arrange

            var expectedResult = new List<User>();
            var user = new User() { Login = "user", Password = "123".GetHashCode(), Role = Role.User };
            var superUser = new User() { Login = "suUser", Password = "123".GetHashCode(), Role = Role.Admin };
            expectedResult.AddRange(new[]
            {
                user,
                superUser
            });
            var userModel = new RegisterModel() { Login = "user", Password = "123", PasswordConfirm = "123" };
            var superUserModel = new RegisterModel() { Login = "suUser", Password = "123", PasswordConfirm = "123" };
            _accountService.Add(userModel);
            _accountService.Add(superUserModel);

            // Act

            var actualResult = _accountService.GetAll().ToList();

            // Assert

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}