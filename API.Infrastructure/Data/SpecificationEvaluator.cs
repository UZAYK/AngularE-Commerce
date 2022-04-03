using API.Core.DbModels;
using API.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Infrastructure.Data
{
    public interface SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// method bir liste döneceği için dönüş tipi IQueryable tipindedir, sorguyu databaseden gelmeden kriterler
        /// uygulanmış olacak. İki parametre var, ilki dışarıdan gelen query diğeri ise uygulanması istenilen kriterlerdir.
        /// 
        /// </summary>
        /// <param name="inputQuery"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery;

            ///Burada uygulanması istenilen bir şart var mı bakıyoruz "where vb. komutlar yani"
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            ///Aggregate = toplu işlem yapmayı sağlar.
            query = spec.Includes.Aggregate(query, (current,include) => current.Include(include));
            return query;

        }
    }
}
