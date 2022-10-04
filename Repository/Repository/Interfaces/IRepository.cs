using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression);
        Task<T> GetById(int? id);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> expression, params string[] includes);

    }
}
