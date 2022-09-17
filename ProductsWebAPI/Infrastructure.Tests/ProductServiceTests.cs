namespace Infrastructure.Tests
{
    using Core.Entities;
    using Infrastructure.Configurations;
    using Infrastructure.Interfaces;
    using Infrastructure.Services;
    using Microsoft.Extensions.Options;
    using System.Diagnostics;

    [TestClass]
    public class ProductServiceTests
    {
        private IProductService _productService;

        [TestInitialize]
        public void TestInitialize()
        {
            ProductsConfiguration config = new ProductsConfiguration() { ProductsDataPath = @"../../../productsTest.json" };
            IOptions<ProductsConfiguration> options = Options.Create(config);
            _productService = new ProductService(options);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _productService = null;
        }

        [TestMethod]
        public void GetAll_DefaultList_FirstAndSecondProducts()
        {
            // Arrange

            List<Product> expectedResult = new List<Product>();
            expectedResult.AddRange(new []
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "first",
                    Price = 1
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "second",
                    Price = 2
                }
            });

            // Act

            var actualResult = _productService.GetAll();

            // Assert

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_SecondProduct_SecondProduct()
        {
            // Arrange

            Product expectedProduct = new Product()
            {
                ProductId = 2,
                Name = "second",
                Price = 2
            };

            // Act

            Product actualProduct = _productService.GetById(expectedProduct.ProductId);

            // Assert

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        [TestMethod]
        public void GetById_NotExistingProduct_Null()
        {
            // Arrange


            // Act

            Product actualProduct = _productService.GetById(3);

            // Assert
            Assert.IsNull(actualProduct);
        }

        [TestMethod]
        public void DeleteOne_SecondProduct_True()
        {
            // Arrange


            // Act

            var actualResult = _productService.DeleteOne(2);

            // Assert

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void DeleteOne_NotExistingProduct_False()
        {
            // Arrange


            // Act

            var actualResult = _productService.DeleteOne(3);

            // Assert

            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void InsertOne_ThirdProduct_True()
        {
            // Arrange

            var product = new Product()
            {
                ProductId = 3,
                Name = "third",
                Price = 3
            };

            // Act

            var actualResult = _productService.InsertOne(product);

            // Assert

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void InsertOne_SecondProduct_False()
        {
            // Arrange

            var product = new Product()
            {
                ProductId = 2,
                Name = "second",
                Price = 2
            };

            // Act

            var actualResult = _productService.InsertOne(product);

            // Assert

            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void UpdateOne_SecondProduct_NotMinusOne()
        {
            // Arrange

            var product = new Product()
            {
                ProductId = 2,
                Name = "second",
                Price = 22
            };

            // Act

            var actualResult = _productService.UpdateOne(product);

            // Assert

            Assert.IsTrue(actualResult != -1);
        }

        [TestMethod]
        public void UpdateOne_ThirdProduct_MinusOne()
        {
            // Arrange

            var product = new Product()
            {
                ProductId = 3,
                Name = "third",
                Price = 3
            };

            // Act

            var actualResult = _productService.UpdateOne(product);

            // Assert

            Assert.IsTrue(actualResult == -1);
        }
    }
}