using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsWebAPI.Controllers
{
    using Core.Entities;
    using Infrastructure.Interfaces;
    using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "User, Admin")]
        public IEnumerable<Product> Get()
        {
            var r = User.Identity.Name;
            return _productService.GetAll();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var result = _productService.GetById(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return new Product();
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public bool Post([FromBody] Product product)
        {
            return _productService.InsertOne(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public int Put(int id, [FromBody] Product product)
        {
            product.ProductId = id;
            return _productService.UpdateOne(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public bool Delete(int id)
        {
            return _productService.DeleteOne(id);
        }
    }
}
