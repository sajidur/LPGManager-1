using LPGManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LPGManager.Data.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync(long tenant);
        Task<User> GetAsync(long id);
        Task<User> AddAsync(User role);
        Task<IEnumerable<User>> Login(string userId, string password);
        Task<User> UpdateAsync(User model);
        Task DeleteAsync(long id);
    }
    public class UserService:IUserService
    {
        private IGenericRepository<User> _genericRepository;

        public UserService(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<User> AddAsync(User user)
        {
            var existing = await _genericRepository.FindBy(c => c.UserId == user.UserId).FirstOrDefaultAsync();
            if (string.IsNullOrWhiteSpace(user.UserId))
                throw new ArgumentException("write user name");
            if (existing != null)
                throw new ArgumentException("Already exist");
            _genericRepository.Insert(user);
            _genericRepository.Save();
            return user;
        }
        public async Task<IEnumerable<User>> GetAllAsync(long tenant)
        {
            var data = await _genericRepository.FindBy(a=>a.TenantId==tenant).ToListAsync();
            return (data);
        }
        public async Task<IEnumerable<User>> Login(string userId,string password)
        {
            var data = _genericRepository.FindBy(a=>a.UserId== userId&&a.Password==password);
            return (data);
        }
        public async Task<User> GetAsync(long id)
        {
            var data = _genericRepository.GetById(id);
            if (data == null)
                throw new ArgumentException("User is not exist");
            return (data.Result);
        }
        public async Task<User> UpdateAsync(User model)
        {
            _genericRepository.Update(model);
            _genericRepository.Save();

            return model;
        }
        public async Task DeleteAsync(long id)
        {
            var existing = _genericRepository.GetById(id);

            if (existing == null)
                throw new ArgumentException("User is not exist");

            _genericRepository.Delete(id);
            _genericRepository.Save();
        }
    }
}
