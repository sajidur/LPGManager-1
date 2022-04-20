using LPGManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LPGManager.Data.Services
{
    public interface ITokenGeneratorService
    {
        JwtSecurityToken GetToken(User user);
    }
    public class TokenGeneratorService: ITokenGeneratorService
    {
        private readonly IConfiguration _configuration;
        public TokenGeneratorService(
          IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JwtSecurityToken GetToken(User user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserId),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            //foreach (var userRole in user.Roles)
            //{
            //    authClaims.Add(new Claim(ClaimTypes.Role, userRole.Name));
            //}
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
