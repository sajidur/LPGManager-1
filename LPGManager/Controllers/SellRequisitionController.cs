using LPGManager.Common;
using LPGManager.Data.Services.SellService;
using LPGManager.Interfaces.SellsInterface;
using LPGManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellRequisitionController : ControllerBase
    {
        private readonly ISellRequisitionMasterService _sellService;

        public SellRequisitionController(ISellRequisitionMasterService sellService)
        {
            _sellService = sellService;
        }
        // GET: api/<PurchaseMasterController(>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenant = Helper.GetTenant(HttpContext);

            var data = _sellService.GetAllAsync(tenant.TenantId);
            return Ok(data);
        }
        //[HttpGet("GetByDate")]
        //public async Task<IActionResult> GetAll(long startDate, long endDate)
        //{
        //    var tenant = Helper.GetTenant(HttpContext);

        //    var data = _sellService.GetAllAsync(tenant.TenantId);
        //    return Ok(data);
        //}
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = _sellService.GetAsync(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SellRequisitionMaster model)
        {
            SellRequisitionMaster result;
            try
            {
                //validation
                var tenant = Helper.GetTenant(HttpContext);
                model.TenantId = tenant.TenantId;
                model.CreatedBy = tenant.Id;
                result = _sellService.AddAsync(model);
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
                await _sellService.DeleteAsync(id);
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
