namespace Banking.API.DTOs.User
{
    public class LoggedInUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountType { get; set; }
        public decimal? Balance { get; set; }
    }
}
