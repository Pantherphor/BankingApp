using Amazon.SimpleNotificationService;
using BankingApp.Applicaition;
using BankingApp.Core;
using BankingApp.Core.Decorators;
using BankingApp.Core.Events;
using BankingApp.Core.Handlers;
using BankingApp.Core.Interfaces;
using BankingApp.Core.Interfaces.Events;
using BankingApp.Core.Interfaces.Factories;
using BankingApp.Core.Interfaces.Repositories;
using BankingApp.Core.Models;
using BankingApp.Infrastructure.Databases;
using BankingApp.Infrastructure.Factories;
using BankingApp.Infrastructure.Logging;
using BankingApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankingApp.API.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<INotificationService, SnsNotificationService>();
            services.AddScoped<ILoggerService, SerilogLoggerService>();

            services.AddAWSService<IAmazonSimpleNotificationService>();

            services.Decorate<IBankAccountService, LoggingDecorator>();
            services.Decorate<INotificationService, NotificationLoggingDecorator>();

        }

        public static void AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IEventPublisher, EventPublisher>();

            services.AddTransient<IEventHandler<WithdrawalEvent>, WithdrawalEventHandler>();

            services.AddTransient<IBankAccountRepository, BankAccountRepository>();

            services.AddTransient(provider => provider.GetRequiredService<IDbContextFactory>().CreateDbContext());
        }

        public static void AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbContextFactory>(provider => new InMemoryDbContextFactory("TestDb"));
        }
    }
}
