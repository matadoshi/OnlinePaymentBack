using DomainModels.PaymentModels;
using Repository.Repository.Interfaces;
using Service.DTO.Category;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IList<CategoryGetDto>> GetAllAsync();
        Task AddAsync(CategoryPostDto item);
        Task<IList<CategoryGetDto>> GetCategoriesWithAttributes();
        Task<CategoryGetDto> GetCategoryById(int? id);
        Task UpdateAsync(int? id, CategoryPutDto item);
        Task DeleteAsync(int? id);
    }
}
