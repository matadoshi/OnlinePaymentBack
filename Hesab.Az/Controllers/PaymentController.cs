using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hesab.Az.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public PaymentController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("Categories")]
        public async Task<IActionResult> Categories()
        {
            return Ok(await _categoryService.GetCategoriesWithAttributes());
        }
    }
}
