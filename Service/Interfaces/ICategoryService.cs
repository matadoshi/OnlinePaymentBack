using DomainModels.PaymentModels;
using Repository.Repository.Interfaces;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService:IRepository<CategoryGetDto>
    {
        Task<IList<CategoryGetDto>> GetCategoriesWithAttributes();
        Task<CategoryGetDto> GetCategoryById(int? id);
    }
}
