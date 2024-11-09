using BankingApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Infrastructure.Databases
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }

}
