using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
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
        {
            return await _ctx.Products.FindAsync(id);
        }

        /// <summary>
        /// All Product List
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

    }
}
