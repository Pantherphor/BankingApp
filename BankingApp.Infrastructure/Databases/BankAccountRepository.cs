using BankingApp.Core.Interfaces.Repositories;
using BankingApp.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Databases
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BankAccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BankAccount> GetAccountByIdAsync(string accountNumber)
        {
            return await Task.FromResult(_dbContext.BankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber));
        }

        public async Task UpdateAccountAsync(BankAccount account)
        {
            _dbContext.BankAccounts.Update(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}
