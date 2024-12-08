using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Models
{
    public class User
    {
        public int Id { get; set; } // PK
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int? BankId { get; set; }
        public BankAccount? BankAccount { get; set; }
       
      
    }
}
