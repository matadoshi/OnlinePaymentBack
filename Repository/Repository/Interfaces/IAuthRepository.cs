using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IAuthRepository:IRepository<User>
    {
        Task<User> Authenticate(string username, string password);
    }
}
