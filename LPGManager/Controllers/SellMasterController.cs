using LPGManager.Dtos;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellMasterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<PurchaseMasterController(>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.sellMasterService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SellMasterDtos model)
        {
            SellMaster result;
            try
            {
                var sellMaster = new SellMaster
                {
                    TotalPrice = model.TotalPrice,
                    Discount = model.Discount,
                    DueAdvance = model.DueAdvance,
                    PaymentType = model.PaymentType,
                    Notes = model.Notes,
                };
                result = await _unitOfWork.sellMasterService.AddAsync(sellMaster);
                await _unitOfWork.SaveAsync();
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
                var sellMaster = new SellMaster
                {
                    Id = model.Id,
                    TotalPrice = model.TotalPrice,
                    Discount = model.Discount,
                    DueAdvance = model.DueAdvance,
                    PaymentType = model.PaymentType,
                    Notes = model.Notes,
                };
                result = await _unitOfWork.sellMasterService.UpdateAsync(sellMaster);
                await _unitOfWork.SaveAsync();
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
                await _unitOfWork.sellMasterService.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
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
