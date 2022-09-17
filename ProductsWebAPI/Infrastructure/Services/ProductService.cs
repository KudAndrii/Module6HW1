using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    using Infrastructure.Interfaces;
    using Newtonsoft.Json;
    using Infrastructure.Configurations;
    using Microsoft.Extensions.Options;
    using Core.Entities;

    public class ProductService : IProductService
    {
        private List<Product> _products;
        public ProductService(IOptions<ProductsConfiguration> productsConfiguration)
        {
            _products = Deserialize<Product>(productsConfiguration.Value.ProductsDataPath);
        }

        public bool DeleteOne(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.SingleOrDefault(p => p.ProductId == id);
        }

        public bool InsertOne(Product model)
        {
            if (_products.SingleOrDefault(p => p.ProductId == model.ProductId) == null)
            {
                _products.Add(model);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UpdateOne(Product model)
        {
            var index = _products.IndexOf(GetById(model.ProductId));
            if (index == -1)
            {
                _products.Add(model);
            }
            else
            {
                _products[index] = model;
            }

            return index;
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
