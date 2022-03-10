using LPGManager.Dtos;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allSupplier = await _unitOfWork.companyService.GetAllAsync();
            return Ok(allSupplier);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CompanyDtos model)
        {
            Company result;
            try
            {
                var supplier = new Company
                {
                    CompanyName = model.CompanyName,
                   // Image = model.Image,
                    Address = model.Address,
                    Phone = model.Phone,
                    CompanyType = model.CompanyType,

                };
                result = await _unitOfWork.companyService.AddAsync(supplier);
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
        public async Task<IActionResult> Update(CompanyDtos model)
        {
            Company result;
            try
            {
                var company = new Company
                {
                    Id = model.Id,
                    CompanyName = model.CompanyName,
                    // Image = model.Image,
                    Address = model.Address,
                    Phone = model.Phone,
                    CompanyType = model.CompanyType,

                };
                result = await _unitOfWork.companyService.AddAsync(company);
                await _unitOfWork.SaveAsync();
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
                await _unitOfWork.companyService.DeleteAsync(id);
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
