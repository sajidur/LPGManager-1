using AutoMapper;
using LPGManager.Common;
using LPGManager.Dtos;
using LPGManager.Interfaces.RoleInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using LPGManager.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IMapper mapper, IRoleService roleService)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        // GET: api/<PurchaseController>      
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _roleService.GetAllAsync();
            return Ok(data);
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(RoleDtos roleDto)
        {
            Role result;
            try
            {
                var role=_mapper.Map<Role>(roleDto);
                var tenant = Helper.GetTenant(HttpContext);
                role.TenantId = tenant.TenantId;
                role.CreatedBy = tenant.Id;
                result = await _roleService.AddAsync(role);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
            return Ok(new { data = result });
        }
    }
}
