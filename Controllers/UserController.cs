using Banking.API.Data;
using Banking.API.DTOs.User;
using Banking.API.Interfaces;
using Banking.API.Mappers;
using Banking.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;
        public UserController(ApplicationDBContext context, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _context = context;
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserWithBankAccount(int userId)
        {
            // Load User and include the related BankAccount
            var user = await _userRepo.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] UserDTO userDTO)
        {
            // Map UserDTO to User entity
            User newUser = UserMapper.UserDTO_To_User(userDTO);

            // Hash the password
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            //create the user
            await _userRepo.CreateUserAsync(newUser);


            // Parse account type from the DTO
            Enum.TryParse(userDTO.AccountType, out AccountType acc);

            // Create the associated BankAccount
            BankAccount bankAcc = new BankAccount
            {
                Balance = 0,
                AccountType = acc, // Set account type from the DTO
                UserId = newUser.Id // Link the user to the bank account using the generated Id
            };

            // Add the BankAccount entity to the DbContext
            await _context.BankAccounts.AddAsync(bankAcc);

            // Save the BankAccount to the database
            await _context.SaveChangesAsync();

            // Update the User entity with the BankAccount reference
            newUser.BankAccount = bankAcc;
            newUser.BankId = bankAcc.Id;

            _context.Users.Update(newUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("exists")]
        public async Task<IActionResult> CheckUsernameExists([FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Username cannot be empty.");
            }

            bool exists = await _userRepo.DoesUserExistAsync(username);
            return Ok(new { exists });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _userRepo.TryLoginAsync(loginDTO);
            if(result == false)
            {
                return Unauthorized("Invalid username or password.");
            }
            else
            {
                return Ok("Login successful!");
            }
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAccountById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest("Invalid account ID.");
        //    }

        //    var account = await _context.Account.FindAsync(id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        _context.Account.Remove(account);
        //        await _context.SaveChangesAsync();
        //        return NoContent(); //204
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(500, "An error occurred while deleting the account.");
        //    }
        //}
    }
}
