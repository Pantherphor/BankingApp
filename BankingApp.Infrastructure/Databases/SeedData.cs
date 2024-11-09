using BankingApp.Core.Models;
using System.Linq;

namespace BankingApp.Infrastructure.Databases
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.BankAccounts.Any())
            {
                return;
            }

            context.BankAccounts.AddRange(
                new BankAccount
                {
                    AccountNumber = "1234567890",
                    Balance = 1000m
                },
                new BankAccount
                {
                    AccountNumber = "0987654321",
                    Balance = 2000m
                }
            );

            context.SaveChanges();
        }
    }

}
