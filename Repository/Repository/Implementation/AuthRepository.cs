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
    public class AuthRepository : EfCoreRepository<User>, IAuthRepository
    {
        public AuthRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<User> Authenticate(string username, string password)
        {
            var user =await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
            return user;
        }
    }
}
