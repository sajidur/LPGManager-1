using LPGManager.Data.Services;
using LPGManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = _tenantService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allSupplier = await _tenantService.GetAllAsync();
            return Ok(allSupplier);
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Create(Tenant model)
        {
            Tenant result;
            try
            {
                result = await _tenantService.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = result });
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(Tenant model)
        {
            Tenant result;
            try
            {
                result = await _tenantService.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = result });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tenantService.DeleteAsync(id);
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
