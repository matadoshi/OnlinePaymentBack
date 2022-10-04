using DomainModels.PaymentModels;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class CategoryRepository : EfCoreRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IList<Category>> GetCategoriesWithAttributes()
        {
            return await _context.Categories.Include(p => p.Attributes).ToListAsync();
        }
        public async Task<Category> GetCategoryById(int? id)
        {
            return await _context.Categories.Include(p=>p.Attributes).FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
