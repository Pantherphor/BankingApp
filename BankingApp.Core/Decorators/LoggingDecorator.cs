using System;
using System.Threading.Tasks;
using BankingApp.Core;
using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using BankingApp.Core.Utilities;

namespace BankingApp.Infrastructure.Logging
{

    public class LoggingDecorator : IBankAccountService
    {
        private readonly IBankAccountService _innerService;
        private readonly ILoggerService _logger;

        public LoggingDecorator(IBankAccountService innerService, ILoggerService logger)
        {
            _innerService = innerService ?? throw new ArgumentNullException(nameof(innerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<BankAccount> GetAccountByIdAsync(string accountNumber)
        {
            _logger.LogInformation(NotificationMessages.StartingMethodFor(nameof(GetAccountByIdAsync), accountNumber));

            try
            {
                var bankAccount = await _innerService.GetAccountByIdAsync(accountNumber);
                if (bankAccount == null)
                {
                    _logger.LogError(new InvalidOperationException(), $"Account not found: {accountNumber}");
                    throw new InvalidOperationException($"Account not found: {accountNumber}");
                }
                return bankAccount;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error occurred during GetAccountByIdAsync for AccountNumber: {accountNumber}");
                throw;
            }
        }

        public async Task<Result> WithdrawAsync(string accountNumber, decimal amount)
        {
            _logger.LogInformation(NotificationMessages.StartingMethodFor(nameof(WithdrawAsync), $"{accountNumber}, Amount: {amount}"));

            try
            {
                var result = await _innerService.WithdrawAsync(accountNumber, amount);

                if (result.IsSuccessful)
                {
                    _logger.LogInformation($"WithdrawAsync successful for AccountNumber: {accountNumber}, Amount: {amount}");
                }
                else
                {
                    _logger.LogWarning($"WithdrawAsync failed for AccountNumber: {accountNumber}, Amount: {amount}. Error: {result.Message}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during WithdrawAsync for AccountNumber: {accountNumber}, Amount: {amount}");
                throw;
            }
        }
    }

}
