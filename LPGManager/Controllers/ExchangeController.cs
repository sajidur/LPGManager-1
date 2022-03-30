using LPGManager.Dtos;
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
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Create(ExchangeDtos model)
        {
            Exchange result;
            try
            {
                var exchange = new Exchange
                {
                    ProductName = model.ProductName,                   
                    Size = model.Size,
                    Price = model.Quantity,
                    AdjustmentAmount = model.AdjustmentAmount,
                    DueAdvance = model.DueAdvance,
                    ReceivingQuantity = model.ReceivingQuantity,
                    ReturnQuantity = model.ReturnQuantity,
                    DamageQuantity = model.DamageQuantity,
                    ComapnyId = model.ComapnyId,

                };
                result = await _unitOfWork.exchangeService.AddAsync(exchange);
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
        public async Task<IActionResult> Update(ExchangeDtos model)
        {
            Exchange result;
            try
            {
                var exchange = new Exchange
                {
                    Id = model.Id,
                    ProductName = model.ProductName,
                    Size = model.Size,
                    Price = model.Quantity,
                    AdjustmentAmount = model.AdjustmentAmount,
                    DueAdvance = model.DueAdvance,
                    ReceivingQuantity = model.ReceivingQuantity,
                    ReturnQuantity = model.ReturnQuantity,
                    DamageQuantity = model.DamageQuantity,
                    ComapnyId = model.ComapnyId,

                };
                result = await _unitOfWork.exchangeService.AddAsync(exchange);
                await _unitOfWork.SaveAsync();
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
                await _unitOfWork.exchangeService.DeleteAsync(id);
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
