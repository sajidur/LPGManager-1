using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models.Settings;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allrole = await _unitOfWork.sizeService.GetAllAsync();
            return Ok(allrole);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(Size model)
        {
            try
            {
                await _unitOfWork.sizeService.AddAsync(model);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

            return Ok(new { data = model });
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Update(Size model)
        {

            try
            {
                await _unitOfWork.sizeService.AddAsync(model);
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
                await _unitOfWork.sizeService.DeleteAsync(id);
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
