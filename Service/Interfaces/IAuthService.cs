using DomainModels.Entities;
using Repository.Repository.Interfaces;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Authenticate(LoginDto model);
        Task Register(RegisterDto model);
        Task ResetPassword(ResetPasswordDto model);
    }
}
