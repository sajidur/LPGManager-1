using LPGManager.Common;
using LPGManager.Data.Services.SellService;
using LPGManager.Dtos;
using LPGManager.Interfaces.SellsInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SellMasterController : ControllerBase
    {
        private readonly ISellMasterService _sellService;
        private readonly IReturnMasterService _returnMaster;
        private readonly ISellRequisitionMasterService _sellRequisitionService;

        public SellMasterController(ISellMasterService sellService, IReturnMasterService returnMaster, ISellRequisitionMasterService sellRequisitionService)
        {
            _sellService = sellService;
            _returnMaster = returnMaster;
            _sellRequisitionService = sellRequisitionService;
        }
        // GET: api/<PurchaseMasterController(>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenant = Helper.GetTenant(HttpContext);

            var data = _sellService.GetAllAsync(tenant.TenantId);
            return Ok(data);
        }
        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetAll(long startDate, long endDate)
        {
            var tenant = Helper.GetTenant(HttpContext);

            var data = _sellService.GetAllAsync(startDate, endDate,tenant.TenantId);
            return Ok(data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = _sellService.GetAsync(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(SellMasterDtos model)
        {
            SellMaster result;
            try
            {
                //validation
                var tenant = Helper.GetTenant(HttpContext);
                model.TenantId = tenant.TenantId;
                model.CreatedBy = tenant.Id;
                result = _sellService.AddAsync(model);
                var requisition=_sellRequisitionService.GetAsync(model.SellRequisitionMasterId);
                if (requisition!=null)
                {
                    requisition.IsActive = 0;
                    _sellRequisitionService.UpdateAsync(requisition);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = result });
        }

        [HttpPost("DueReceive")]
        public async Task<IActionResult> DueReceive(List<DueReceiveDtos> dueReceives)
        {
            try
            {
                //validation
                var tenant = Helper.GetTenant(HttpContext);
                var result=_sellService.DueReceive(dueReceives,tenant).Result;
                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

        }

        [HttpPost("Delivery")]
        public async Task<IActionResult> Delivery(DeliveryDtos delivery)
        {
            SellMaster result;
            try
            {
                result= _sellService.Delivery(delivery).Result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = result });
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return(ReturnMasterDtos model)
        {
            ReturnMaster result;
            try
            {
                //validation
                var tenant = Helper.GetTenant(HttpContext);
                model.TenantId = tenant.TenantId;
                model.CreatedBy = tenant.Id;
                result = _returnMaster.AddAsync(model);
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
                var tenant = Helper.GetTenant(HttpContext);
                model.TenantId = tenant.TenantId;
                model.CreatedBy = tenant.Id;
                result = await _sellService.UpdateAsync(model);
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
                await _sellService.DeleteAsync(id);
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
