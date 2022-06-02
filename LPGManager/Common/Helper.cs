using LPGManager.Dtos;
using LPGManager.Models;
using System.Security.Claims;

namespace LPGManager.Common
{
    public class Helper
    {

       public static DateTime Epoch2UTCNow(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }
       public static long ToEpoch(DateTime dateTime)
        {
            var Epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return Epoch;
        }

        public static User GetTenant(HttpContext context)
        {
            var tenant = context.User.Claims.Where(a => a.Type == ClaimTypes.Actor).FirstOrDefault().Value;
            var id = context.User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var UserId = context.User.Claims.Where(a => a.Type == ClaimTypes.Name).FirstOrDefault().Value;
            var UserType = context.User.Claims.Where(a => a.Type == ClaimTypes.Role).FirstOrDefault().Value;
            return new User()
            {
                Id=Convert.ToInt64(id),
                UserId=UserId,
                UserType=Convert.ToInt32(UserType),
                TenantId= Convert.ToInt64(tenant)
            };
        }
    }
}
