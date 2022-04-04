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

        public SellMasterController(ISellMasterService sellService)
        {
            _sellService = sellService;
        }
        // GET: api/<PurchaseMasterController(>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _sellService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SellMasterDtos model)
        {
            SellMaster result;
            try
            {
                //validation
                result = _sellService.AddAsync(model);
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
