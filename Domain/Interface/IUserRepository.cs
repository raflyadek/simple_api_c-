using Domain.Entities;

namespace Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(int id);
    }
}