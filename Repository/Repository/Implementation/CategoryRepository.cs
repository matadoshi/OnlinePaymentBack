using DomainModels.PaymentModels;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class CategoryRepository : EfCoreRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Category> FirstOrDefault(int? id)
        {
            return await appDbContext.Categories.Include(p=>p.Attributes).FirstOrDefaultAsync(p => p.Id == id);
        }
        public AppDbContext appDbContext { get { return Db as AppDbContext; } }
    }

}
