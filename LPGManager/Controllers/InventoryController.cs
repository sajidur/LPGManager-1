using AutoMapper;
using LPGManager.Common;
using LPGManager.Dtos;
using LPGManager.Interfaces.InventoryInterface;
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
        private readonly IInventoryService  _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        // GET: api/<InventoryController>      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenant = Helper.GetTenant(HttpContext);
            var data = _inventoryService.GetAllAsync(tenant.TenantId);
            return Ok(data);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(long companyId)
        {
            var tenant = Helper.GetTenant(HttpContext);
            var data = _inventoryService.GetAllAsync(tenant.TenantId,companyId);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(InventoryDtos model)
        {
            Inventory result;
            try
            {
                var tenant = Helper.GetTenant(HttpContext);
                model.TenantId = tenant.TenantId;
                model.CreatedBy = tenant.Id;
                result = _inventoryService.AddAsync(model);
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
                result = _inventoryService.AddAsync(model);
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
                await _inventoryService.DeleteAsync(id);
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
