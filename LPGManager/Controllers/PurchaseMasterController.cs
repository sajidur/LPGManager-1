using AutoMapper;
using LPGManager.Dtos;
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

        public PurchaseMasterController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: api/<PurchaseMasterController(>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.purchaseMasterService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(PurchaseMasterDtos model)
        {
            PurchaseMaster result;
            try
            {
                var purchase=_mapper.Map<PurchaseMaster>(model);
                if (model.PurchaseDetails!=null)
                {
                    foreach (var item in model.PurchaseDetails)
                    {
                        var purchasedetails = _mapper.Map<PurchaseDetails>(item);
                        purchase.PurchasesDetails.Add(purchasedetails);
                    }
                }
                result = await _unitOfWork.purchaseMasterService.AddAsync(purchase);
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
        public async Task<IActionResult> Update(PurchaseMasterDtos model)
        {
            PurchaseMaster result;
            try
            {
                var purchase = _mapper.Map<PurchaseMaster>(model);
                if (model.PurchaseDetails != null)
                {
                    foreach (var item in model.PurchaseDetails)
                    {
                        var purchasedetails = _mapper.Map<PurchaseDetails>(item);
                        purchase.PurchasesDetails.Add(purchasedetails);
                    }
                }
                result = await _unitOfWork.purchaseMasterService.UpdateAsync(purchase);
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
