using API.Core.DbModels;
using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        => Ok(await _productRepository.GetProductAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id) 
        => await _productRepository.GetProductByIdAsync(id);

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() 
        => Ok(await _productRepository.GetProductBrandsAsync());

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes() 
        => Ok(await _productRepository.GetProductTypesAsync());

    }
}
