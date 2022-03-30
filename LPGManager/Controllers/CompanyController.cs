using LPGManager.Data.Services.CompanyService;
using LPGManager.Dtos;
using LPGManager.Interfaces.CompanyInterface;
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
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allSupplier = await _companyService.GetAllAsync();
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
                result = await _companyService.AddAsync(supplier);
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
                result = await _companyService.AddAsync(company);
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
                await _companyService.DeleteAsync(id);
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
