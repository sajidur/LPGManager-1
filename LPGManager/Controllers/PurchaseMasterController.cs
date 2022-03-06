using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseMasterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<PurchaseController>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allSupplier = await _unitOfWork.purchaseMasterService.GetAllAsync();
            return Ok(allSupplier);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(PurchaseMaster model)
        {
            try
            {
                model = await _unitOfWork.purchaseMasterService.AddAsync(model);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(model);
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(PurchaseMaster model)
        {
            try
            {
                model = await _unitOfWork.purchaseMasterService.UpdateAsync(model);
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
                await _unitOfWork.purchaseMasterService.DeleteAsync(id);
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
