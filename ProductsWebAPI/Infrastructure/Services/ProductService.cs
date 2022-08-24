using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    using Core;
    using Infrastructure.Interfaces;
    using Newtonsoft.Json;
    using Infrastructure.Extentions;
    public class ProductService : IProductService
    {
        private const string _productInfoPath = @"C:\Users\cudan\Documents\GitHub\Module6HW1\ProductsWebAPI\Infrastructure\ProductsInfo.json";
        public List<ProductModel> _products;
        public ProductService()
        {
            _products = Deserialize<ProductModel>(_productInfoPath);
        }

        public void DeleteOne(int id)
        {
            _products.Remove(GetById(id));
        }

        public List<ProductModel> GetAll()
        {
            return _products;
        }

        public ProductModel GetById(int id)
        {
            return _products.SingleOrDefault(p => p.ProductId == id);
        }

        public void InsertOne(ProductModel model)
        {
            _products.Add(model);
        }

        public void UpdateOne(ProductModel model)
        {
            var oldProduct = _products.SingleOrDefault(p => p.ProductId == model.ProductId);
            if (oldProduct is not null)
            {
                oldProduct.ReplaceNotNullProperties(model);
            }
            else
            {
                _products.Add(model);
            }
        }

        /// <summary>
        /// Method gets original state of list of products.
        /// </summary>
        /// <typeparam name="TModel">Model of product.</typeparam>
        /// <param name="path">Path to JSON file of list of products.</param>
        /// <returns>List of TModels.</returns>
        /// <exception cref="DirectoryNotFoundException">Exception which will be thrown if file by given path is empty.</exception>
        private List<TModel> Deserialize<TModel>(in string path)
        {
            var configFile = File.ReadAllText(path);
            if (string.IsNullOrEmpty(configFile))
            {
                throw new DirectoryNotFoundException();
            }

            return JsonConvert.DeserializeObject<List<TModel>>(configFile);
        }
    }
}
