using AutoMapper;
using LPGManager.Data.Services;
using LPGManager.Dtos;
using LPGManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace LPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private ITokenGeneratorService _tokenGeneratorService;
        public UserController(ITokenGeneratorService tokenGeneratorService,IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenGeneratorService = tokenGeneratorService;
        }
        // GET: api/<PurchaseController>      
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _userService.GetAllAsync();
            return Ok(data);
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(UserDtos userDto)
        {
            User result;
            try
            {
                var role = _mapper.Map<User>(userDto);
                result = await _userService.AddAsync(role);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }
            return Ok(new { data = result });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string userId,string password)
        {
            User result;
            try
            {
                result = _userService.Login(userId, password).Result.FirstOrDefault();
                var token=_tokenGeneratorService.GetToken(result);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    id=result.Id,
                    Name=result.Name,
                    UserId=result.UserId,
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
