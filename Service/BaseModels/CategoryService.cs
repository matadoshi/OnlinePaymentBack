using DomainModels.PaymentModels;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.BaseModels
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> _category;
        public CategoryService(IRepository<Category> category)
        {
            _category = category;
        }
        public async Task<Category> GetService(int? id)
        {
            Category category = await _category.GetAllAsync()
                .Include(p => p.Attributes)
                .FirstOrDefaultAsync(p => p.Id == id);
            return category;
        }
    }
}
