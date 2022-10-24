using AutoMapper;
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
            ledgerSummary.TotalQty = customerLedger.SellList.Sum(a => (a.SellsDetails.Sum(b => b.Quantity)+ a.SellsDetails.Sum(b => b.OpeningQuantity)+ a.SellsDetails.Sum(b => b.ReceivingQuantity)- a.SellsDetails.Sum(b => b.ReturnQuantity)));
            return Ok(customerLedger);
        }
    }
}
