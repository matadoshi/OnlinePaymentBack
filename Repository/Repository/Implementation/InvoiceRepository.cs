using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class InvoiceRepository : EfCoreRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<List<Invoice>> GetInvoices(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var invoices = await _context.Invoices.Include(r=>r.User).Include(r=>r.Transaction).Where(u => u.UserId == user.Id).ToListAsync();
            return invoices;
        }
        public async Task<List<Invoice>> GetInvoicesAll()
        {
            var invoices = await _context.Invoices.Include(r => r.User).Include(r => r.Transaction).ToListAsync();
            return invoices;
        }
    }
}
