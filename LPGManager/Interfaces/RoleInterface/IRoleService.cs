using LPGManager.Models;

namespace LPGManager.Interfaces.RoleInterface
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(int id);
        Task<Role> AddAsync(Role supplier);
        Task<Role> UpdateAsync(Role model);
        Task DeleteAsync(int id);
    }
}
