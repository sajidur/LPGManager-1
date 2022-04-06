using LPGManager.Dtos;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LPGManager.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<PurchaseController>      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.purchaseDetailsService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(PurchaseDetailsDtos model)
        {
            PurchaseDetails result;
            try
            {
                var purchaseDetails = new PurchaseDetails
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
                    SaleQuantity = model.SaleQuantity,
                    PurchaseMasterId = model.PurchaseMasterId,
                    CompanyId = model.CompanyId,

                };
                Inventory inventory = new Inventory
                {
                    ProductName = purchaseDetails.ProductName,
                    Size = purchaseDetails.Size,
                    ProductType = purchaseDetails.ProductType,
                    Price = purchaseDetails.Price,
                    Quantity = purchaseDetails.Quantity,
                    OpeningQuantity = purchaseDetails.OpeningQuantity,
                    ReceivingQuantity = purchaseDetails.ReceivingQuantity,
                    ReturnQuantity = purchaseDetails.ReturnQuantity,
                    DamageQuantity = purchaseDetails.DamageQuantity,
                    SaleQuantity = purchaseDetails.SaleQuantity,
                    WarehouseId = 1,
                    CompanyId = purchaseDetails.CompanyId,


                };
                result = await _unitOfWork.purchaseDetailsService.AddAsync(purchaseDetails);
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
        public async Task<IActionResult> Update(PurchaseDetailsDtos model)
        {
            PurchaseDetails result;
            try
            {
                var purchaseDetails = new PurchaseDetails
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
                    SaleQuantity = model.SaleQuantity,
                    PurchaseMasterId = model.PurchaseMasterId,
                    CompanyId = model.CompanyId,

                };
                result = await _unitOfWork.purchaseDetailsService.UpdateAsync(purchaseDetails);
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
                await _unitOfWork.purchaseDetailsService.DeleteAsync(id);
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
