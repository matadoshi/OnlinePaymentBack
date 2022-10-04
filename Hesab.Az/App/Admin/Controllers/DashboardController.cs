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

namespace Hesab.Az.App.Admin.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accService;

        public DashboardController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAccountService accService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accService = accService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            User foundByEmail = await _userManager.FindByEmailAsync(model.Email);

            if (foundByEmail != null && await _userManager.CheckPasswordAsync(foundByEmail, model.Password))
            {
                var token = await _accService.CreateJwtToken(foundByEmail);
                return Ok(new
                {
                    token = token
                });
            }
            return NotFound("Your credentials don’t match. It’s probably attributable to human error.");
        }

    }
}
