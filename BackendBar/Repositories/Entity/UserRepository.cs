using BackendBar.Interfaces;
using BackendBar.Models;
using BackendBar.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendBar.Repositories.Entity
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendBarDbContext _context;
        public UserRepository(BackendBarDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> getAllUsers()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> userById(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task addUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> deleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User?> updateUserById(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Phone = user.Phone;
                existingUser.Email = user.Email;
                await _context.SaveChangesAsync();
                return existingUser;
            }
            return null;
        }
    }
}
