using LPGManager.Dtos;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<SellDetailsController>      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.sellDetailsService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SellDetailsDtos model)
        {
            SellDetails result;
            try
            {
                var sellDetails = new SellDetails
                {
                    ProductName = model.ProductName,
                    Size = model.Size,
                    ProductType = model.ProductType,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    OpeningQuantity = model.OpeningQuantity,
                    ReceivingQuantity = model.ReceivingQuantity,
                    ReturnQuantity = model.ReturnQuantity,
                    DamageQuantity = model.DamageQuantity,
                    SellMasterId = model.SellMasterId,

                };
                result = await _unitOfWork.sellDetailsService.AddAsync(sellDetails);
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
        public async Task<IActionResult> Update(SellDetailsDtos model)
        {
            SellDetails result;
            try
            {
                var sellDetails = new SellDetails
                {
                    Id = model.Id,
                    ProductName = model.ProductName,
                    Size = model.Size,
                    ProductType = model.ProductType,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    OpeningQuantity = model.OpeningQuantity,
                    ReceivingQuantity = model.ReceivingQuantity,
                    ReturnQuantity = model.ReturnQuantity,
                    DamageQuantity = model.DamageQuantity,
                    SellMasterId = model.SellMasterId,                    

                };
                result = await _unitOfWork.sellDetailsService.UpdateAsync(sellDetails);
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
                await _unitOfWork.sellDetailsService.DeleteAsync(id);
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
