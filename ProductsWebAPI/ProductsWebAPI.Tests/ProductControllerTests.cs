using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Infrastructure.Interfaces;
using Moq;
using ProductsWebAPI.Controllers;
using ProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsWebAPI.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        private ProductsController _productController;

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IProductService> mockProductService = new Mock<IProductService>();

            mockProductService
                .Setup(s => s.GetAll())
                .Returns(new List<Product>()
                {
                    new Product()
                    {
                        ProductId = 1,
                        Name = "first",
                    }
                });

            mockProductService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .Returns(new Product()
                {
                    ProductId = 1,
                    Name = "first",
                });

            mockProductService
                .Setup(s => s.InsertOne(It.IsAny<Product>()))
                .Returns(true);

            mockProductService
                .Setup(s => s.UpdateOne(It.IsAny<Product>()))
                .Returns(1);

            mockProductService
                .Setup(s => s.DeleteOne(It.IsAny<int>()))
                .Returns(true);

            _productController = new ProductsController(mockProductService.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _productController = null;
        }

        [TestMethod]
        public void Get_DefaultList_FirstProduct()
        {
            // Arrange

            var expectedResult = new List<Product>()
                {
                    new Product()
                    {
                        ProductId = 1,
                        Name = "first",
                    }
                };

            // Act

            var actualResult = _productController.Get();

            // Assert

            CollectionAssert.AreEqual(expectedResult, expectedResult);
        }

        [TestMethod]
        public void Get_FirstProduct_SameProduct()
        {
            // Arrange

            var expectedResult = new Product()
            {
                ProductId = 1,
                Name = "first",
            };

            // Act

            var actualResult = _productController.Get(1);

            // Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Get_NotExistingProduct_EmptyProduct()
        {
            // Arrange

            // Act

            var actualResult = _productController.Get(2);

            // Assert

            Assert.AreEqual(new Product(), actualResult);
        }

        [TestMethod]
        public void Post_ValidProduct_True()
        {
            // Arrange

            var product = new Product()
            {
                ProductId = 2,
                Name = "second",
            };

            // Act

            var actualResult = _productController.Post(product);

            // Assert

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void Put_ExistingProduct_One()
        {
            // Arrange

            var product = new Product()
            {
                ProductId = 1,
                Name = "newName",
            };

            // Act

            var actualResult = _productController.Put(1, product);

            // Assert

            Assert.IsTrue(actualResult == 1);
        }

        [TestMethod]
        public void Delete_ExistingProduct_True()
        {
            // Arrange

            // Act

            var actualResult = _productController.Delete(1);

            // Assert

            Assert.IsTrue(actualResult);
        }
    }
}
