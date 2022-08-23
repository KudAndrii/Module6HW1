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
        private IProductService _productService;
        public ProductsController(IProductService productService) => _productService = productService;

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
        public void Post([FromBody] ProductModel product)
        {
            _productService.InsertOne(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProductModel product)
        {
            product.ProductId = id;
            _productService.UpdateOne(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteOne(id);
        }
    }
}
