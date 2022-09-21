using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO.Slider;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Hesab.Az.App.Areas.Admin.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sliderService.GetAllAsync());
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromForm] SliderPostDto model)
        {
            await _sliderService.AddAsync(model);
            return StatusCode(201);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(int? id, [FromForm] SliderPutDto model)
        {
            id = model.Id;
            await _sliderService.UpdateAsync(id, model);
            return StatusCode(204);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await _sliderService.DeleteAsync(id);
            return Ok();
        }
    }

}
