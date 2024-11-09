namespace BankingApp.Core.Utilities
{
    public static class ErrorMessages
    {
        public static string InvalidPayload => "Invalid event payload.";

        public static string AccountNotFound(string accountNumber) =>
            $"Account not found: {accountNumber}";

        public static string InsufficientFunds(string accountNumber, decimal amount) =>
            $"Insufficient funds for account: {accountNumber}. Attempted withdrawal: {amount}";

        public static string InvalidAccountNumber(string accountNumber) =>
            $"Invalid account number: {accountNumber}.";
    }

    public static class NotificationMessages
    {
        public static string WithdralLimit => "Withdrawal amount exceeds limit.";

        public static string WithdralSuccessful => "Withdrawal successful.";

        public static string StartingMethodFor(string method, string message)
        {
            return $"Starting {method} for: {message}";
        }
    }

}
