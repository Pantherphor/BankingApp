using BankingApp.Core.Interfaces.Factories;
using BankingApp.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Infrastructure.Factories
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        private readonly string _databaseName;

        public InMemoryDbContextFactory(string databaseName)
        {
            _databaseName = databaseName;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(_databaseName)
                .Options;

            return new ApplicationDbContext(options);
        }
    }

}
