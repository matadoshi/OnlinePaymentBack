using AutoMapper;
using DomainModels.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Repository.Interfaces;
using Service.DTO;
using Service.DTO.Account;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _jwt;
        private readonly IMapper _mapper;
        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<AppSettings> jwt, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> Login(LoginDto model)
        {
            var authenticationModel = new LoginResponseDto();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"No Accounts Registered with {model.Email}.";
                return authenticationModel;
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password) && user.EmailConfirmed == true)
            {
                authenticationModel.IsAuthenticated = true;
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authenticationModel.Email = user.Email;
                authenticationModel.Id = user.Id;
                authenticationModel.Image = user.Image;
                authenticationModel.FullName = user.FullName;
                authenticationModel.Phone = user.PhoneNumber;
                authenticationModel.UserName = user.UserName;
                authenticationModel.Birthday = user.Birthday;
                authenticationModel.Gender = user.Gender;
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationModel.Roles = rolesList.ToList();
                return authenticationModel;
            }
            authenticationModel.IsAuthenticated = false;
            authenticationModel.Message = $"Incorrect Credentials for user {user.Email}.";
            return authenticationModel;
        }
        public async Task Register(RegisterDto model)
        {
            User user = _mapper.Map<User>(model);
            IdentityResult identityResult = await _userManager.CreateAsync(user, model.Password);
            if (!identityResult.Succeeded)
            {
                throw new BadRequestException(identityResult.Errors.ToString());
            }
            await _userManager.AddToRoleAsync(user, "Member");
        }
        public async Task ResetPassword(ResetPasswordDto model)
        {
            User user = await _userManager.FindByIdAsync(model.Id);

            if (model.CurrentPassword != null)
            {
                if (model.NewPassword == null)
                {
                    throw new BadRequestException("Password is required");
                }
                if (model.NewPassword != model.ConfirmPassword)
                {
                    throw new BadRequestException("New Password is not matched");
                }
                if (!await _userManager.CheckPasswordAsync(user, model.CurrentPassword))
                {
                    throw new BadRequestException("current Password is incorrect");
                }

                IdentityResult identity = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!identity.Succeeded)
                {
                    foreach (var item in identity.Errors)
                    {
                        throw new BadRequestException(item.Description.ToString());
                    }
                }
            }
        }
        public async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        public async Task UpdateAsync(AccountUpdateDto model)
        {
            User user = await _userManager.FindByIdAsync(model.Id);

            user.FullName = model.Fullname;
            user.Image = model.Image;
            user.PhoneNumber = model.Phone;
            user.Gender = model.Gender;
            user.Birthday = model.Birthday;
            user.Id = model.Id;
            IdentityResult identity = await _userManager.UpdateAsync(user);

            if (!identity.Succeeded)
            {
                foreach (var item in identity.Errors)
                {
                    throw new BadRequestException(item.Description.ToString());
                }
            }
        }
        public async Task<JwtSecurityToken> LoginForAdmin(LoginDto model)
        {
            User appUser = await _userManager.FindByEmailAsync(model.Email);
            if (!await _userManager.IsInRoleAsync(appUser, "Member"))
            {
                if (appUser == null)
                {
                    throw new Exception("Email or password incorrect");
                }
                if (!await _userManager.CheckPasswordAsync(appUser, model.Password))
                {
                    throw new Exception("Email or password incorrect");
                }

                return await CreateJwtToken(appUser);
            }

            throw new Exception("Are you member???");
        }
    }
}

