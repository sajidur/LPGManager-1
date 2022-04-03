using LPGManager.Dtos;
using LPGManager.Interfaces.SupplierInterface;
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
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allSupplier = await _supplierService.GetAllAsync();
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
                    Image = model.Image,
                    Address = model.Address,
                    Phone = model.Phone,
                    Companytype = model.Companytype,                  

                };
                result = await _supplierService.AddAsync(supplier);
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
                    Id = model.Id,
                    SupplierName = model.Name,
                   // Image = model.Image,
                    Address = model.Address,
                    Phone = model.Phone,
                    Companytype = model.Companytype,

                };
                result = await _supplierService.AddAsync(supplier);
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
                await _supplierService.DeleteAsync(id);
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
