using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
