using DomainModels.PaymentModels;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class AttributeRepository : EfCoreRepository<Attributes>, IAttributeRepository
    {
        public AttributeRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Attributes> GetDataForAttributes(int? id)
        {
            var attributes= await _context.Attributes.Include(r=>r.Category).ToListAsync();
            return attributes.Find(r => r.Id == id);
        }
    }
}
