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
    public class CardRepository : EfCoreRepository<Card>, ICardRepository
    {
        public CardRepository(AppDbContext context):base(context)
        {

        }
        public async Task<List<Card>> GetCards(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var cards = await _context.Cards.Where(u=>u.UserId==user.Id).ToListAsync();
            return cards;
        }
    }
}