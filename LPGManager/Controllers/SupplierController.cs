using LPGManager.Common;
using LPGManager.Data.Services;
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
        private readonly ITenantService _tenantService;

        public SupplierController(ISupplierService supplierService, ITenantService tenantService)
        {
            _supplierService = supplierService;
            _tenantService = tenantService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenant = Helper.GetTenant(HttpContext);
            var allSupplier = await _supplierService.GetAllAsync(tenant.TenantId);
            return Ok(allSupplier);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SupplierDtos model)
        {
            
            Supplier result;
            //Tenant tenant = new Tenant()
            //{
            //    TenantName = model.Name,
            //    Image = model.Image,
            //    Address = model.Address,
            //    Phone = model.Phone,
            //    Tenanttype =(int) TenantType.Supplier,
            //    IsActive=1,
            //    CreatedBy=0,
            //    CreatedDate=DateTime.Now            
            //};
            //var tenResult=_tenantService.AddAsync(tenant);
            var tenant = Helper.GetTenant(HttpContext);

            try
            {
                var supplier = new Supplier
                {
                    SupplierName = model.Name,
                    Image = model.Image,
                    Address = model.Address,
                    Phone = model.Phone,
                    Companytype = model.Companytype,                  
                    TenantId= tenant.TenantId
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
