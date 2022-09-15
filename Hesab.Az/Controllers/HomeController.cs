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
        private readonly ICategoryService _categoryService;
        private readonly IRepository<Category> _category;
        private readonly ISliderService _sliderService;
        private readonly ICustomerService _customerService;
        public HomeController(ICategoryService categoryService, IRepository<Category> category, ISliderService sliderService, ICustomerService customerService)
        {
            _categoryService = categoryService;
            _category = category;
            _sliderService = sliderService;
            _customerService = customerService;
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
        public async Task<IActionResult> GetSlider()
        {
            var slider =await _sliderService.GetSlider();
            return Ok(slider);
        }
        public async Task<IActionResult> GetCustomer()
        {
            var customer = await _customerService.GetCustomers();
            return Ok(customer);
        }
    }
}
