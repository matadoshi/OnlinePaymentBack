using DomainModels.PaymentModels;
using Repository.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<IList<Category>> GetCategoriesWithAttributes();
        Task<Category> GetCategoryById(int? id);
    }
}
