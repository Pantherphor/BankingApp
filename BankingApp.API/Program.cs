using System;
using BankingApp.Core.Interfaces;
using BankingApp.Infrastructure.Databases;
using BankingApp.Infrastructure.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BankingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            try
            {
                LoggingConfiguration.ConfigureSerilog(builder);
                Log.Information("Starting up the application");
                var host = CreateHostBuilder(args, builder).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var environment = services.GetRequiredService<IHostEnvironment>();
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    if (environment.IsDevelopment())
                    {
                        try
                        {
                            SeedData.Initialize(context);
                        }
                        catch (Exception ex)
                        {
                            var logger = services.GetRequiredService<ILoggerService>();
                            logger.LogError(ex, "An error occurred while seeding the database.");
                        }
                    }
                }

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application startup failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });



    }
}
