namespace Banking.API.Models
{
    public class Account
    {
        public int Id { get; set; } // Unique identifier for the account
        public string Name { get; set; } // Name of the account holder
        public decimal Balance { get; set; } // Current balance of the account
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Account creation timestamp
    }
}
    