using LPGManager.Dtos;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LPGManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allSupplier = await _unitOfWork.supplierService.GetAllAsync();
            return Ok(allSupplier);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SupplierDtos model)
        {
            Supplier result;
            try
            {
                var supplier = new Supplier
                {
                    SupplierName = model.Name,
                   // Image = model.Image,
                    Address = model.Address,
                    Phone = model.Phone,
                    Companytype = model.Companytype,                  

                };
                result = await _unitOfWork.supplierService.AddAsync(supplier);
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
        public async Task<IActionResult> Update(SupplierDtos model)
        {
            Supplier result;
            try
            {
                var supplier = new Supplier
                {
                    SupplierId = model.Id,
                    SupplierName = model.Name,
                   // Image = model.Image,
                    Address = model.Address,
                    Phone = model.Phone,
                    Companytype = model.Companytype,

                };
                result = await _unitOfWork.supplierService.AddAsync(supplier);
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
                await _unitOfWork.supplierService.DeleteAsync(id);
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
