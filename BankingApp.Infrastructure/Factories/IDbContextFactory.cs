using BankingApp.Infrastructure.Databases;

namespace BankingApp.Core.Interfaces.Factories
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext();
    }

}
