using Domain.Entities;

namespace Application.Interface;

public interface IUserService
{
    Task<User> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}