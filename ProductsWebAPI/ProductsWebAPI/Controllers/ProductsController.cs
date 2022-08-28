using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsWebAPI.Controllers
{
    using Core;
    using Infrastructure.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _productService.GetAll();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return _productService.GetById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public bool Post([FromBody] ProductModel product)
        {
            return _productService.InsertOne(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] ProductModel product)
        {
            product.ProductId = id;
            return _productService.UpdateOne(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _productService.DeleteOne(id);
        }
    }
}
