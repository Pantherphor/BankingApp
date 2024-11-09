namespace BankingApp.Core.Utilities
{
    public class Result
    {
        public bool IsSuccessful { get; private set; }
        public string Message { get; private set; }

        private Result(bool success, string message)
        {
            IsSuccessful= success;
            Message = message;
        }

        public static Result Success(string message) => new(true, message);
        public static Result Fail(string message) => new(false, message);
    }

}
