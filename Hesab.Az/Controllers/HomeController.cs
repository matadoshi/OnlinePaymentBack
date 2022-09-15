using DomainModels.PaymentModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.Interfaces;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Hesab.Az.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public readonly IRepository<Category> _category;
        public HomeController(ICategoryService categoryService, IRepository<Category> category)
        {
            _categoryService = categoryService;
            _category = category;
        }
        [HttpGet()]
        public async Task<IActionResult> GetServices()
        {
            var services = await _category.GetAllAsync();
            return Ok(services);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            var services = await _categoryService.GetService(id);
            return Ok(services);
        }
    }
}
