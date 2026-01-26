using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    // Task<User> GetByIdAsync(int id);
    //     Task<User> GetAllAsync();
    //     Task<User> CreateAsync(User user);
    //     Task<User> UpdateAsync(User user);
    //     Task<User> DeleteAsync(int id);
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _context;

        //dependency injection?
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //get all 
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        //get by id
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        //update
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        //create
        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //delete
        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

}