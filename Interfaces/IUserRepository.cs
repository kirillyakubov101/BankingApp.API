using Banking.API.DTOs.User;
using Banking.API.Models;

namespace Banking.API.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id);
        public Task<User> CreateUserAsync(User user);
        public Task<User?> DeleteUserAsync(int id);
        public Task<bool> DoesUserExistAsync(string username);
        public Task<bool> TryLoginAsync(LoginDTO loginDTO);
    }
}
