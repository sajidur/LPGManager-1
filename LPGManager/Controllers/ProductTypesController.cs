using LPGManager.Data.Services.SettingsService;
using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models.Settings;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productService;

        public ProductTypesController(IProductTypeService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductTypesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allrole = await _productService.GetAllAsync();
            return Ok(allrole);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(ProductType model)
        {
            try
            {
                await _productService.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = model });
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(ProductType model)
        {

            try
            {
                await _productService.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = model });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _productService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"{ex}.");
            }
            return Ok();
        }
    }
}
