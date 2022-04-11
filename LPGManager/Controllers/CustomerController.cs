using AutoMapper;
using LPGManager.Data.Services.CustomerService;
using LPGManager.Dtos;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        // GET: api/<PurchaseController>      
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _customerService.GetAllAsync();
            return Ok(data);
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customer=_mapper.Map<CustomerEntity>(customerDto);
            _customerService.Save(customer);
            return Ok();
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(CustomerDto model)
        {
            CustomerEntity result;
            try
            {
                var customer = _mapper.Map<CustomerEntity>(model);
                _customerService.UpdateAsync(customer);
                return Ok();
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
                await _customerService.DeleteAsync(id);
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
