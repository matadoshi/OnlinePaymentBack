using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<bool> AddAsync(T item);
        bool UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
    }
}
