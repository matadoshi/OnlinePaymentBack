using DomainModels.PaymentModels;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService:ICategoryRepository
    {
        Task<Category> GetCategory(int? id);
    }
}
