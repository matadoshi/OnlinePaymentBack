using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetInvoices(string id);
    }
}
