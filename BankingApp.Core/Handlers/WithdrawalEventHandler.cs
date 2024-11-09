using BankingApp.Core.Interfaces;
using BankingApp.Core.Interfaces.Events;
using BankingApp.Core.Models;
using System.Threading.Tasks;

namespace BankingApp.Core.Handlers
{
    public class WithdrawalEventHandler : IEventHandler<WithdrawalEvent>
    {
        private readonly INotificationService _notificationService; 

        public WithdrawalEventHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(WithdrawalEvent withdrawalEvent)
        {
            await _notificationService.PublishEventAsync(withdrawalEvent);
        }
    }

}
