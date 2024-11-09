﻿using System;

namespace BankingApp.Core.Interfaces
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(Exception exception, string message);
    }

}
