using API.Core.DbModels;
using API.Infrastructure.DataContext;
using API.Infrastructure.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly ProductRepository _productRepository;

        public ProductsController(StoreContext storeContext, ProductRepository productRepository)
        {
            _storeContext = storeContext;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = _productRepository.GetProductAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id) => await _productRepository.GetProductByIdAsync(id);

    }
}
