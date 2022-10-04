using DomainModels.PaymentModels;
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
            return await _context.Attributes.FindAsync(id);
        }
    }
}
