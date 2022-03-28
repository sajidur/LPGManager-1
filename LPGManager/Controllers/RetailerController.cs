using LPGManager.Interfaces.UnitOfWorkInterface;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    public class RetailerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RetailerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<PurchaseController>      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.purchaseDetailsService.GetAllAsync();
            return Ok(data);
        }
    }
}
