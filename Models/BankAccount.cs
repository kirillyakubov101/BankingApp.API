using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Models
{
    public enum AccountType
    {
        Checking = 1,
        Savings = 2,
        Business = 3
    }
    public class BankAccount
    {
        public int Id { get; set; } //PK
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; } //FK
        public User User { get; set; }
    }
}
    