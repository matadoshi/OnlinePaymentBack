using Microsoft.AspNetCore.Http;
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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accService;

        public AccountsController(IAccountService accService)
        {
            _accService = accService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginForAdmin(LoginDto model)
        {
            return Ok(await _accService.LoginForAdmin(model));
        }

    }
}
