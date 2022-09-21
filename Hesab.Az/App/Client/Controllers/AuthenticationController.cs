using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hesab.Az.App.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AuthenticationController(IAuthService authService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IEmailService emailService)
        {
            _authService = authService;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailService = emailService;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = _authService.Authenticate(model);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto model)
        {
            await _authService.Register(model);
            User user = await _userManager.FindByEmailAsync(model.Email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("ConfirmEmail", "Authentication", new { userId = user.Id, token = code }, Request.Scheme, Request.Host.ToString());
            _emailService.SenderEmail(model, link);
            return Ok();
        }
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordDto model)
        {
            await _authService.ResetPassword(model);
            return NoContent();
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            User user = await _userManager.FindByIdAsync(userId);
            await _userManager.ConfirmEmailAsync(user, token);
            return Ok();
        }
        [HttpPost("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {

        }
    }
}
