using AutoMapper;
using LPGManager.Common;
using LPGManager.Data.Services.CustomerService;
using LPGManager.Data.Services.SellService;
using LPGManager.Dtos;
using LPGManager.Interfaces.SellsInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLedgerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ISellMasterService _sellMasterService;
        private readonly IMapper _mapper;
        public CustomerLedgerController(IMapper mapper, ICustomerService customerService, ISellMasterService sellMasterService)
        {
            _customerService = customerService;
            _sellMasterService = sellMasterService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int customerId)
        {
            CustomerLedgerView customerLedger = new CustomerLedgerView();
            var customer = await _customerService.GetById(customerId);
            customerLedger.Customer =_mapper.Map<CustomerDto>(customer);
            //sell
            customerLedger.SellList = _sellMasterService.GetAllAsyncByCustomerId(customerId);
            //summary
            LedgerSummary ledgerSummary= new LedgerSummary();
            ledgerSummary.TotalDiscount = customerLedger.SellList.Sum(a => a.Discount);
            ledgerSummary.TotalSupport = customerLedger.SellList.Sum(a => a.SellsDetails.Sum(b=>b.SupportQty));
            ledgerSummary.TotalBottleQty = customerLedger.SellList.Sum(a => (a.SellsDetails.Where(a=>a.ProductName==ProductNameEnum.Bottle.ToString()).Sum(b => b.Quantity)+ a.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Bottle.ToString()).Sum(b => b.OpeningQuantity)+ a.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Bottle.ToString()).Sum(b => b.ReceivingQuantity)- a.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Bottle.ToString()).Sum(b => b.ReturnQuantity)));
            ledgerSummary.TotalRiffleQty = customerLedger.SellList.Sum(a => (a.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Refill.ToString()).Sum(b => b.Quantity) + a.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Refill.ToString()).Sum(b => b.OpeningQuantity) + a.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Refill.ToString()).Sum(b => b.ReceivingQuantity) - a.SellsDetails.Where(a => a.ProductName == ProductNameEnum.Refill.ToString()).Sum(b => b.ReturnQuantity)));
            ledgerSummary.TotalReturnQty = customerLedger.SellList.Sum(a => (a.ReturnMaster.Sum(b => b.TotalReturnQty)));
            ledgerSummary.TotalDue = customerLedger.SellList.Sum(a => a.TotalDue);
            customerLedger.LedgerSummary = ledgerSummary;
            return Ok(customerLedger);
        }
    }
}
