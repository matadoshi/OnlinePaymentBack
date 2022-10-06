using DomainModels.Entities;
using Repository.Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repo;

        public InvoiceService(IInvoiceRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Invoice>> GetInvoices(string id)
        {
            var invoices = _repo.GetInvoices(id);
            return invoices;
        }
        public Task<List<Invoice>> GetInvoicesAll()
        {
            return _repo.GetInvoicesAll();
        }
    }
}
