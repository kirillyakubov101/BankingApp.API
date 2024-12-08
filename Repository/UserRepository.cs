using Banking.API.Data;
using Banking.API.DTOs.User;
using Banking.API.Interfaces;
using Banking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DoesUserExistAsync(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> TryLoginAsync(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginDTO.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash))
            {
                return false;
            }

            return true;
        }
    }
}
