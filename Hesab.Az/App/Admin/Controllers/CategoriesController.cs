using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO.Category;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Hesab.Az.App.Areas.Admin.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromForm] CategoryPostDto model)
        {
            await _categoryService.AddAsync(model);
            return StatusCode(201);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(int? id,[FromForm] CategoryPutDto model)
        {
            id=model.Id;
            await _categoryService.UpdateAsync(id, model);
            return StatusCode(204);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
