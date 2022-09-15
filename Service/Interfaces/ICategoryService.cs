using DomainModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryd(int? id);
    }
}
