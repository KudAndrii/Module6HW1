namespace Core
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    public class ProductModel
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}