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
        public List<ProductModel> GetAll();

        public ProductModel GetById(int id);
        public void InsertOne(ProductModel model);
        public void UpdateOne(ProductModel model);
        public void DeleteOne(int id);
    }
}
