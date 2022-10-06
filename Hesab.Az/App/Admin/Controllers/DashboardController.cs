using DomainModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.Interfaces;
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
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashboardController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accService;
        private readonly IInvoiceService _invoiceService;

        public DashboardController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAccountService accService, IInvoiceService invoiceService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accService = accService;
            _invoiceService = invoiceService;
        }
        [HttpGet]
        [Route("GetInvoices")]
        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _invoiceService.GetInvoicesAll();
        }
    }
}
