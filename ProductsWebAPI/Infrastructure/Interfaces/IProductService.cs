using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    using Core;
    public interface IProductService
    {
        /// <summary>
        /// Method returns all products.
        /// </summary>
        /// <returns>List of products.</returns>
        public List<ProductModel> GetAll();

        /// <summary>
        /// Method returns product by given id.
        /// </summary>
        /// <param name="id">ProductId property of ProductModel which should be found.</param>
        /// <returns>ProductModel object.</returns>
        public ProductModel GetById(int id);

        /// <summary>
        /// Method adds product to List of ProductModels.
        /// </summary>
        /// <param name="model">ProductModel which should be added.</param>
        public void InsertOne(ProductModel model);

        /// <summary>
        /// Method updates existing product in list, or adds it if list don't contains it.
        /// </summary>
        /// <param name="model">ProductModel which should be updated.</param>
        public void UpdateOne(ProductModel model);

        /// <summary>
        /// Method deletes product from list of ProductModels by given id. 
        /// </summary>
        /// <param name="id">ProductId property of ProductModel which should be deleted.</param>
        public void DeleteOne(int id);
    }
}
