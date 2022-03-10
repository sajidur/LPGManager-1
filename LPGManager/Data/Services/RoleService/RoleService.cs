using LPGManager.Interfaces.RoleInterface;
using LPGManager.Models;

using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services.RoleService
{
    public class RoleService : Interfaces.RoleInterface.IRoleService
    {
        private readonly AppsDbContext _dbContext;

        public RoleService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Role> AddAsync(Role role)
        {
            var existing = await _dbContext.Roles.FirstOrDefaultAsync(c => c.Id == role.Id);
            if (string.IsNullOrWhiteSpace(role.Name))
                throw new ArgumentException("Write Role name");
            if (existing != null)
                throw new ArgumentException("Already exist");

            _dbContext.Roles.Add(role);

            return role;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var data = await _dbContext.Roles.ToListAsync();
            return (data);
        }
        public async Task<Role> GetAsync(int id)
        {
            var data = await _dbContext.Roles.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
                throw new ArgumentException("Roles is not exist");
            return (data);
        }
        public async Task<Role> UpdateAsync(Role model)
        {
            var existing = await _dbContext.Roles.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Role name not found");
            if (existing == null)
                throw new ArgumentException("Role is not exist");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);

            return model;
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _dbContext.Roles.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                throw new ArgumentException("Role is not exist");

            _dbContext.Roles.Remove(existing);
        }
    }
}
