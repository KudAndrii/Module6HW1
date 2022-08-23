using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MyExtentions
{
    using Core;
    public static class ProductModelExtentions
    {
        public static void ReplaceNotNullProperties(this ProductModel productForChanging, ProductModel newProduct)
        {
            if (newProduct.ProductId is not null)
            {
                productForChanging.ProductId = newProduct.ProductId;
            }

            if (newProduct.Name is not null)
            {
                productForChanging.Name = newProduct.Name;
            }

            if (newProduct.Url is not null)
            {
                productForChanging.Url = newProduct.Url;
            }

            if (newProduct.Price is not null)
            {
                productForChanging.Price = newProduct.Price;
            }

            if (newProduct.ShortDescription is not null)
            {
                productForChanging.ShortDescription = newProduct.ShortDescription;
            }

            if (newProduct.Description is not null)
            {
                productForChanging.Description = newProduct.Description;
            }
        }
    }
}
