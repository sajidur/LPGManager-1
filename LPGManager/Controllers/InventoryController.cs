using LPGManager.Dtos;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<PurchaseController>      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.inventoryService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(InventoryDtos model)
        {
            Inventory result;
            try
            {
                var inventory = new Inventory
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
                    WarehouseId = model.WarehouseId,
                    SupplierId = model.SupplierId,

                };
                result = await _unitOfWork.inventoryService.AddAsync(inventory);
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
        public async Task<IActionResult> Update(InventoryDtos model)
        {
            Inventory result;
            try
            {
                var inventory = new Inventory
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
                    WarehouseId = model.WarehouseId,
                    SupplierId = model.SupplierId,

                };
                result = await _unitOfWork.inventoryService.AddAsync(inventory);
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
                await _unitOfWork.inventoryService.DeleteAsync(id);
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
