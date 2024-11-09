using BankingApp.Core.Models;
using BankingApp.Core.Utilities;
using System.Threading.Tasks;

namespace BankingApp.Core
{
    public interface IBankAccountService
    {
        Task<BankAccount> GetAccountByIdAsync(string accountNumber);
        Task<Result> WithdrawAsync(string accountNumber, decimal amount);
    }
}