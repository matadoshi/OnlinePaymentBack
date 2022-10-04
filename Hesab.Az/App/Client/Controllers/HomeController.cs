using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Hesab.Az.App.Client.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ISliderService _sliderService;
        private readonly IAttributeService _attributeService;
        private readonly ICustomerService _customerService;
        public HomeController(ICategoryService categoryService, ISliderService sliderService, ICustomerService customerService, IAttributeService attributeService)
        {
            _categoryService = categoryService;
            _sliderService = sliderService;
            _customerService = customerService;
            _attributeService = attributeService;
        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            var services = await _categoryService.GetCategoriesWithAttributes();
            return Ok(services);
        }
        [HttpGet("pay/{id}")]
        public async Task<IActionResult> GetAttibute([FromRoute] int? id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpGet("pay/next/{id}")]
        public async Task<IActionResult> GetDataForAttribute([FromRoute] int? id)
        {
            return Ok(await _attributeService.GetDataForAttributes(id));
        }
        [HttpGet("GetSlider")]
        public async Task<IActionResult> GetSlider()
        {
            var slider = await _sliderService.GetAllAsync();
            return Ok(slider);
        }
        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomer()
        {
            var customer = await _customerService.GetCustomers();
            return Ok(customer);
        }
    }
}
