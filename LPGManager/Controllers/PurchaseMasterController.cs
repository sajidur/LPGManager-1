using AutoMapper;
using LPGManager.Common;
using LPGManager.Dtos;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseMasterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        IPurchaseMasterService _masterService;
        public PurchaseMasterController(IPurchaseMasterService masterService,IMapper mapper)
        {
            _mapper = mapper;
            _masterService = masterService;
        }
        // GET: api/<PurchaseMasterController(>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _masterService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetAll(long startDate, long endDate)
        {
            var tenant = Helper.GetTenant(HttpContext);
            var data = _masterService.GetAllAsync(startDate, endDate,tenant.TenantId);
            return Ok(data);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Create(PurchaseMasterDtos model)
        {
            var tenant = Helper.GetTenant(HttpContext);
            model.TenantId = tenant.TenantId;
            model.CreatedBy = tenant.Id;
            var result = _masterService.AddAsync(model);
            return Ok(new { data = result });
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(PurchaseMasterDtos model)
        {
            var tenant = Helper.GetTenant(HttpContext);
            model.TenantId = tenant.TenantId;
            model.CreatedBy = tenant.Id;
            var result = await _masterService.UpdateAsync(model);
            return Ok(new { data = result });

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //try
            //{
            //    await _unitOfWork.purchaseMasterService.DeleteAsync(id);
            //    await _unitOfWork.SaveAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new ArgumentException(
            //        $"{ex}.");
            //}
            //return Ok();
            var res= _masterService.DeleteAsync(id);
            return Ok();
        }
    }
}
