using AutoMapper;
using LPGManager.Common;
using LPGManager.Data.Services;
using LPGManager.Data.Services.CustomerService;
using LPGManager.Dtos;
using LPGManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace LPGManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private ITokenGeneratorService _tokenGeneratorService;
        private ITenantService _tenantService;
        private ICustomerService _customerService;
        public UserController(ICustomerService customerService,ITenantService _tenantService,ITokenGeneratorService tokenGeneratorService,IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenGeneratorService = tokenGeneratorService;
            this._tenantService = _tenantService;
            _customerService = customerService;
        }
        // GET: api/<PurchaseController>      
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var tenant = Helper.GetTenant(HttpContext);
            var data = await _userService.GetAllAsync(tenant.TenantId);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("Save")]
        public async Task<IActionResult> Save(UserDtos userDto)
        {
            User result;
            try
            {
                var role = _mapper.Map<User>(userDto);
                //save tenant info when signup
                if (userDto.TenantId==0&&!string.IsNullOrEmpty(userDto.TenantName))
                {
                    var res = _tenantService.AddAsync(new Tenant()
                    {
                        TenantName = userDto.TenantName,
                        Tenanttype = userDto.UserType,
                        Address = "",
                        IsActive = 1,
                        Phone = userDto.Phone
                    });
                    role.TenantId = res.Result.Id;
                }
                else if(userDto.TenantId == 0 && string.IsNullOrEmpty(userDto.TenantName))
                {
                    return BadRequest("Please provide valid Tenant Information");
                }
                //end
                result = await _userService.AddAsync(role);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
            return Ok(new { data = result });
        }

        [HttpPost("updatePassword")]
        public async Task<IActionResult> updatePassword(PasswordUpdateDtos model)
        {
            User result;
            try
            {
                var tenant = Helper.GetTenant(HttpContext);
                var user = _userService.GetAsync(tenant.Id).Result;
                if (user.Password== model.oldPassWord)
                {
                    user.Password = model.newPassword;
                }
                else
                {
                    return Ok("Previews password not correct");
                }
                result = _userService.UpdateAsync(user ?? null).Result;
                return Ok(new
                {
                    id = result.Id,
                    Name = result.Name,
                    UserId = result.UserId,
                    Address = result.Address,
                    Phone = result.Phone,
                    userType = result.UserType
                });

            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
            return Ok(new { data = result });
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDtos userDtos)
        {
            User result;
            try
            {
                var tenant = Helper.GetTenant(HttpContext);
                var user = _userService.GetAsync(tenant.Id).Result;
                user.Address = userDtos.Address;
                user.Phone = userDtos.Phone;
                user.Name = userDtos.Name;
                result = _userService.UpdateAsync(user ?? null).Result;
                return Ok(new
                {
                    id = result.Id,
                    Name = result.Name,
                    UserId = result.UserId,
                    Address = result.Address,
                    Phone = result.Phone,
                    userType = result.UserType
                });

            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
            return Ok(new { data = result });
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string userId,string password)
        {
            User result;
            try
            {
                result = _userService.Login(userId, password).Result.FirstOrDefault();
                if (result==null)
                {
                    return Ok (new { data = "Password not match" });
                }
                var token=_tokenGeneratorService.GetToken(result);
                return Ok(new
                {
                    token = "Bearer "+ new JwtSecurityTokenHandler().WriteToken(token),
                    id=result.Id,
                    Name=result.Name,
                    UserId=result.UserId,
                    Address = result.Address,
                    Phone = result.Phone,
                    userType=result.UserType,
                    expiration = token.ValidTo
                });

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
