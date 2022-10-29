using AutoMapper;
using LPGManager.Common;
using LPGManager.Data.Services;
using LPGManager.Data.Services.CustomerService;
using LPGManager.Data.Services.Ledger;
using LPGManager.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILedgerPostingService _ledgerPostingService;
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        public LedgerController(IMapper mapper, ICustomerService customerService, ITenantService tenantService, ILedgerPostingService ledgerPostingService)
        {
            _customerService = customerService;
            _tenantService = tenantService;
            _ledgerPostingService = ledgerPostingService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("Payment")]
        public async Task<IActionResult> Payment(LedgerPostingDtos ledgerPosting)
        {
            var tenant = Helper.GetTenant(HttpContext);
            ledgerPosting.CreatedBy = tenant.Id;
            _ledgerPostingService.AddAsync(ledgerPosting);
            return Ok();
        }
        [AllowAnonymous]

        [HttpPost("Receive")]
        public async Task<IActionResult> Receive(LedgerPostingDtos ledgerPosting)
        {
            var tenant = Helper.GetTenant(HttpContext);
            ledgerPosting.CreatedBy = tenant.Id;
            _ledgerPostingService.AddAsync(ledgerPosting);
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int customerId)
        {
            var data = _ledgerPostingService.FindByLedgerId(customerId);
            return Ok(data);
        }
    }
}
