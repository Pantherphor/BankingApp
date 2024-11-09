using BankingApp.Core.Interfaces;
using Serilog;
using System;

namespace BankingApp.Infrastructure.Services
{
    public class SerilogLoggerService : ILoggerService
    {
        private readonly ILogger _logger;

        public SerilogLoggerService()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void LogInformation(string message)
        {
            _logger.Information(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }
        public void LogError(Exception exception, string message)
        {
            _logger.Error(exception, message);
        }

    }

}
