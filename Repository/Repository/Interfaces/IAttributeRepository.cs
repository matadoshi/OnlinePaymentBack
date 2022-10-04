using DomainModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IAttributeRepository
    {
        Task<Attributes> GetDataForAttributes(int? id);
    }
}
