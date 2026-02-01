using Application.Interface;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Repositories;

namespace Application
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        //get all
        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        //get by id
        public async Task<User> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        //update
        public async Task UpdateAsync(User user)
        {
            await _repository.UpdateAsync(user);
        }

        //delete
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        //create
        public async Task<User> CreateAsync(User user)
        {
            return await _repository.CreateAsync(user);
        }
    }
    
}