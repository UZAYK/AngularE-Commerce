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
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;

        public ProductsController(IGenericRepository<Product> productRepository,
        IGenericRepository<ProductBrand> productBrandRepository,
        IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        => Ok(await _productRepository.ListAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id) 
        => await _productRepository.GetByIdAsync(id);

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() 
        => Ok(await _productBrandRepository.ListAllAsync());

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes() 
        => Ok(await _productTypeRepository.ListAllAsync());

    }
}
