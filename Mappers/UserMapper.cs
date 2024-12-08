using Banking.API.DTOs.User;
using Banking.API.Models;

namespace Banking.API.Mappers
{
    public static class UserMapper
    {
        public static User UserDTO_To_User(UserDTO userDTO)
        {
            return new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                PasswordHash = userDTO.Password,
                Username = userDTO.Username,
                Address = userDTO.Address,
                PhoneNumber = userDTO.PhoneNumber,

            };
        }

        public static UserDTO User_To_UserDTO(User user)
        {
            return new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.PasswordHash,
                Username = user.Username,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
