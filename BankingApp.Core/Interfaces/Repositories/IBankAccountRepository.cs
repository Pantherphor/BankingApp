using BankingApp.Core.Models;
using System.Threading.Tasks;

namespace BankingApp.Core.Interfaces.Repositories
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> GetAccountByIdAsync(string accountNumber);
        Task UpdateAccountAsync(BankAccount account);
    }
}
