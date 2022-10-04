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
    public class UserRepository:EfCoreRepository<User>,IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
