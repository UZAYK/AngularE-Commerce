using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _ctx;
        public ProductRepository(StoreContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        ///  Product Get ById (First)
        /// </summary>
        /// <returns></returns>
        public async Task<Product> GetProductByIdAsync(int id)
        => await _ctx.Products
                     .Include(p => p.ProdutBrand)
                     .Include(p => p.ProdutType)
                     .FirstOrDefaultAsync(p=>p.Id == id);

        /// <summary>
        /// All Product List
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        => await _ctx.Products
                 .Include(p => p.ProdutBrand)
                 .Include(p => p.ProdutType)
                 .ToListAsync();

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        => await _ctx.ProductTypes
                 .ToListAsync();

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        => await _ctx.ProductBrands
                 .ToListAsync();
    }
}
