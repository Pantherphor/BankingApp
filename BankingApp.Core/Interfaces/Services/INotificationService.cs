using BankingApp.Core.Models;
using System.Threading.Tasks;

namespace BankingApp.Core.Interfaces
{
    public interface INotificationService
    {
        Task PublishEventAsync(WithdrawalEvent withdrawalEvent);
    }
}
