using DomainModels.Entities;
using Repository.Repository.Interfaces;
using Service.DTO;
using Service.DTO.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponseDto> Login(LoginDto model);
        Task Register(RegisterDto model);
        Task ResetPassword(ResetPasswordDto model);
        Task UpdateAsync(AccountUpdateDto model);
        Task<JwtSecurityToken> CreateJwtToken(User user);
        Task<JwtSecurityToken> LoginForAdmin(LoginDto model);
    }
}
