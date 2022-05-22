using LPGManager.Common;
using LPGManager.Dtos;
using LPGManager.Interfaces.ExchangeInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Create(ExchangeMasterDtos model)
        {
            ExchangeMaster result;
            try
            {
                var tenant = Helper.GetTenant(HttpContext);
                model.TenantId = tenant.TenantId;
                model.CreatedBy = tenant.Id;
                result = _exchangeService.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = result });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _exchangeService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetAll(long startDate, long endDate)
        {
            var data = _exchangeService.GetAllAsync(startDate, endDate);
            return Ok(data);
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(ExchangeMaster model)
        {
            ExchangeMaster result;
            try
            {
                result = await _exchangeService.UpdateAsync(model);
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
                await _exchangeService.DeleteAsync(id);
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
