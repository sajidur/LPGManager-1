using LPGManager.Common;
using LPGManager.Data.Services.SellService;
using LPGManager.Dtos;
using LPGManager.Interfaces.SellsInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SellMasterController : ControllerBase
    {
        private readonly ISellMasterService _sellService;
        private readonly IReturnMasterService _returnMaster;

        public SellMasterController(ISellMasterService sellService, IReturnMasterService returnMaster)
        {
            _sellService = sellService;
            _returnMaster = returnMaster;
        }
        // GET: api/<PurchaseMasterController(>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _sellService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetAll(long startDate, long endDate)
        {
            var data = _sellService.GetAllAsync(startDate, endDate);
            return Ok(data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = _sellService.GetAsync(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SellMasterDtos model)
        {
            SellMaster result;
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
        [HttpPost("return")]
        public async Task<IActionResult> Return(ReturnMasterDtos model)
        {
            ReturnMaster result;
            try
            {
                //validation
                var tenant = Helper.GetTenant(HttpContext);
                sell.TenantId = tenant.TenantId;
                sell.CreatedBy = tenant.Id;
                result = _returnMaster.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = result });
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(SellMasterDtos model)
        {
            SellMaster result;
            try
            {
                var tenant = Helper.GetTenant(HttpContext);
                sell.TenantId = tenant.TenantId;
                sell.CreatedBy = tenant.Id;
                result = await _sellService.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"{ex}.");
            }
            return Ok(new { data = model });
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
