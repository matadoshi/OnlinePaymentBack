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

namespace Hesab.Az.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AuthenticationController(IAuthService authService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _authService = authService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LoginDto model)
        {
            var user = _authService.Authenticate(model);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }
        //[HttpGet("CreateRole")]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Ok();
        //}
        //[HttpGet("CreateSuperAdmin")]
        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    User appUser = new User
        //    {
        //        Email = "superadmin@hesab.az",
        //        UserName = "SuperAdmin",
        //        FullName = "Onur Ismailov"
        //    };

        //    await _userManager.CreateAsync(appUser, "SuperAdmin@123");
        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

        //    return Ok("Super Admin Was Successfully Created");
        //}
    }
}
