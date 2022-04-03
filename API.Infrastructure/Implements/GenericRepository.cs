using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Infrastructure.Data;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    /// new() = newlenebilir olma şartını koyar (yani class olacak, örn interface newlenemez)
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly StoreContext _ctx;
        public GenericRepository(StoreContext ctx)
        => _ctx = ctx;

        public async Task<T> GetByIdAsync(int id)
        => await _ctx.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync()
        => await _ctx.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec)
        => await ApplySpecification(spec).ToListAsync();

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        => await ApplySpecification(spec).FirstOrDefaultAsync();

        private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
        => SpecificationEvaluator<T>.GetQuery(_ctx.Set<T>().AsQueryable(), spec);
    }
}
