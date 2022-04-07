using LPGManager.Models;

namespace LPGManager.Interfaces.RoleInterface
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(long id);
        Task<Role> AddAsync(Role role);
        Task<Role> UpdateAsync(Role model);
        Task DeleteAsync(long id);
    }
}
