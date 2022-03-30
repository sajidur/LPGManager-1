using AutoMapper;
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
            //var data = await _unitOfWork.purchaseMasterService.GetAllAsync();
            //return Ok(data);
            return null;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(PurchaseMasterDtos model)
        {
            //PurchaseMaster result;
            //try
            //{
            //    var purchase=_mapper.Map<PurchaseMaster>(model);
            //    if (model.PurchaseDetails!=null)
            //    {
            //        foreach (var item in model.PurchaseDetails)
            //        {
            //            var purchasedetails = _mapper.Map<PurchaseDetails>(item);
            //            purchase.PurchasesDetails.Add(purchasedetails);
            //            var inv = _unitOfWork.inventoryService.GetInventory(item.ProductName, item.Size, item.CompanyId, item.ProductType, 1);
            //            if (inv != null)
            //            {
            //                inv.Quantity += item.Quantity;
            //                inv.ReceivingQuantity += item.Quantity;
            //            }
            //            else
            //            {
            //                inv=new Inventory();
            //                inv.WarehouseId = 1;
            //                inv.CompanyId = item.CompanyId;
            //                inv.DamageQuantity = 0;
            //                inv.ReceivingQuantity = item.Quantity;
            //                inv.OpeningQuantity = 0;
            //                inv.Price = item.Price;
            //                inv.Quantity = item.Quantity;
            //                inv.SaleQuantity = 0;
            //                inv.ReturnQuantity = 0;
            //                inv.ProductType = item.ProductType;
            //                inv.ProductName = item.ProductName;
            //                inv.Size = item.Size;                           
            //            }
            //            _unitOfWork.inventoryService.AddAsync(inv);

            //        }
            //    }
            //    result = await _unitOfWork.purchaseMasterService.AddAsync(purchase);
            //    await _unitOfWork.SaveAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new ArgumentException(
            //      $"{ex}.");
            //}
            var result = _masterService.AddAsync(model);
            return Ok(new { data = result });
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(PurchaseMasterDtos model)
        {
            //PurchaseMaster result;
            //try
            //{
            //    var purchaseMaster = new PurchaseMaster
            //    {
            //        Id = model.Id,
            //        TotalPrice = model.TotalPrice,
            //        TotalCommission = model.TotalCommission,
            //        DueAdvance = model.DueAdvance,
            //        PaymentType = model.PaymentType,
            //        Notes = model.Notes,
            //        SupplierId = model.SupplierId,
            //    };
            //    result = await _unitOfWork.purchaseMasterService.UpdateAsync(purchaseMaster);
            //    await _unitOfWork.SaveAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new ArgumentException(
            //        $"{ex}.");
            //}
            //return Ok(new { data = model });
            return null;
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
            return null;
        }
    }
}
