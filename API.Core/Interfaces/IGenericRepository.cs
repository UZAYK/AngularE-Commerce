
using API.Core.DbModels;
using API.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
/// <summary>
/// BaseEntity = baseEntityden miras almış ve yani class olma şartını koyar
/// new() = newlenebilir olma şartını koyar (yani class olacak, örn interface newlenemez)
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// IReadOnlyList = çekilen dataların sadece gösterimde kulanılacağı bildirilmiş olur, 
        /// entityFramework'nin arka taraftaki kopyalanmış entity bize vermemesini sağlamış oluruz,
        /// Amaç : Performans arttırım
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAllAsync();


        //Specification Evaluator Methodhs
        Task<T> GetEntityWithSpec(ISpecifications<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);
        Task<int> CountAsync(ISpecifications<T> spec);
    }
}
