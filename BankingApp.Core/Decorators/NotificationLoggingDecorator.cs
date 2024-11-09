using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using System;
using System.Threading.Tasks;

namespace BankingApp.Core.Decorators
{
    public class NotificationLoggingDecorator : INotificationService
    {
        private readonly INotificationService _snsNotificationService;
        private readonly ILoggerService _logger;

        public NotificationLoggingDecorator(INotificationService snsNotificationService, ILoggerService logger)
        {
            _snsNotificationService = snsNotificationService ?? throw new ArgumentNullException(nameof(snsNotificationService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        } 

        public async Task PublishEventAsync(WithdrawalEvent withdrawalEvent)
        {
            try
            {
                _logger.LogInformation($"Preparing to publish event for AccountNumber: {withdrawalEvent.AccountNumber}, Amount: {withdrawalEvent.Amount}");

                await _snsNotificationService.PublishEventAsync(withdrawalEvent);

                _logger.LogInformation($"Successfully published event for AccountNumber: {withdrawalEvent.AccountNumber}, Amount: {withdrawalEvent.Amount}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while publishing event for AccountNumber: {withdrawalEvent.AccountNumber}");
                throw;
            }
        }
    }

}
