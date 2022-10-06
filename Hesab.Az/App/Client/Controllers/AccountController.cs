using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.DTO.Account;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hesab.Az.App.Client.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AccountController(IAccountService authService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IEmailService emailService)
        {
            _accService = authService;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailService = emailService;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = _accService.Login(model);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto model)
        {
            await _accService.Register(model);
            User user = await _userManager.FindByEmailAsync(model.Email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = code }, Request.Scheme, Request.Host.ToString());
            await _emailService.SendEmailAsync(model.Email,null, link,null);
            return Ok();
        }
        [HttpPut("ProfileEdit")]
        public async Task<IActionResult> Edit([FromForm] AccountUpdateDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            await _accService.UpdateAsync(model);
            return Ok();
        }
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordDto model)
        {
            await _accService.ResetPassword(model);
            return Ok();
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            User user = await _userManager.FindByIdAsync(userId);
            await _userManager.ConfirmEmailAsync(user, token);
            return Ok();
        }
    }
}
