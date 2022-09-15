using DomainModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> FirstOrDefault(int? id);
    }
}
