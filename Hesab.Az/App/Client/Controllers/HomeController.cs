using DomainModels.PaymentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.Interfaces;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Hesab.Az.App.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ISliderService _sliderService;
        private readonly ICustomerService _customerService;
        public HomeController(ICategoryService categoryService, ISliderService sliderService, ICustomerService customerService)
        {
            _categoryService = categoryService;
            _sliderService = sliderService;
            _customerService = customerService;
        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            var services = await _categoryService.GetAllAsync();
            return Ok(services);
        }
        [HttpGet("Attribute/{id}")]
        public async Task<IActionResult> GetAttibute([FromRoute] int? id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpGet("GetSlider")]
        public async Task<IActionResult> GetSlider()
        {
            var slider = await _sliderService.GetAllAsync();
            return Ok(slider);
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var customer = await _customerService.GetCustomers();
            return Ok(customer);
        }
    }
}
