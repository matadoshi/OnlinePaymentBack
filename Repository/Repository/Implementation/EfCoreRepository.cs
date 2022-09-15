using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class EfCoreRepository<T>: IRepository<T> where T : class
    {
        protected readonly AppDbContext Db;

        public EfCoreRepository(AppDbContext db)
        {
            Db = db;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Db.Set<T>().ToListAsync();
        }


        public async Task<bool> AddAsync(T item)
        {
            try
            {
                await Db.Set<T>().AddAsync(item);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(T item)
        {
            try
            {
                Db.Set<T>().Remove(item);
                await Db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateAsync(T item)
        {
            try
            {
                Db.Set<T>().Update(item);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
