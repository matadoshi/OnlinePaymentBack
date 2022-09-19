using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class EfCoreRepository<T>: IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public EfCoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> AddAsync(T item)
        {
            try
            {
                await _context.Set<T>().AddAsync(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        Task IRepository<T>.AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(expression);

            if (includes != null && includes.Length > 0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
    }   
}
