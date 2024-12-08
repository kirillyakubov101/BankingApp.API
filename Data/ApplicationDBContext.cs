using Banking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        //TABLES
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
