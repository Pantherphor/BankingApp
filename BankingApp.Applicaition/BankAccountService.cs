using BankingApp.Core;
using BankingApp.Core.Events;
using BankingApp.Core.Interfaces;
using BankingApp.Core.Interfaces.Repositories;
using BankingApp.Core.Models;
using BankingApp.Core.Utilities;
using BankingApp.Core.Validations;
using System;
using System.Threading.Tasks;

namespace BankingApp.Applicaition
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _accountRepository;
        private readonly ILoggerService _logger;
        private readonly IEventPublisher _eventPublisher;

        public BankAccountService(IBankAccountRepository accountRepository, ILoggerService logger, IEventPublisher eventPublisher)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _eventPublisher = eventPublisher;
        }

        public async Task<BankAccount> GetAccountByIdAsync(string accountNumber)
        {
            var bankAccount = await _accountRepository.GetAccountByIdAsync(accountNumber);
            if (bankAccount == null)
            {
                _logger.LogError(new InvalidOperationException(), ErrorMessages.AccountNotFound(accountNumber));
                throw new InvalidOperationException(ErrorMessages.AccountNotFound(accountNumber));
            }
            return bankAccount;
        }

        public async Task<Result> WithdrawAsync(string accountNumber, decimal amount)
        {
            var withdrawalEvent = new WithdrawalEvent
            {
                AccountNumber = accountNumber,
                Amount = amount,
                Status = WithdrawalStatus.Pending
            };

            if (!EventValidator.TryValidate(withdrawalEvent, out var validationErrors))
            {
                return Result.Fail(ErrorMessages.InvalidPayload);
            }

            var account = await GetAccountByIdAsync(accountNumber);

            if (account.Balance < amount)
            {
                _logger.LogError(new Exception(), ErrorMessages.InsufficientFunds(accountNumber, amount));
                return Result.Fail(NotificationMessages.WithdralLimit);
            }

            account.Balance -= amount;

            await _accountRepository.UpdateAccountAsync(account);

            await _eventPublisher.Publish(withdrawalEvent);

            return Result.Success(NotificationMessages.WithdralSuccessful);
        }
    }

}
