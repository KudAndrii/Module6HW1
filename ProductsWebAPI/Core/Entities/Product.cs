namespace Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public override bool Equals(object? obj)
        {
            var result = false;

            if (obj is Product)
            {
                var product = obj as Product;

                result = ProductId == product.ProductId ? true : false;
                result = Name == product.Name ? true : false;
                result = Url == product.Url ? true : false;
                result = Price == product.Price ? true : false;
                result = ShortDescription == product.ShortDescription ? true : false;
                result = Description == product.Description ? true : false;
            }

            return result;
        }
    }
}