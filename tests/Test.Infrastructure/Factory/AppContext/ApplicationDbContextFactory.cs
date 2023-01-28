using Test.Infrastructure.DatabaseConfig.Integration;

namespace Test.Infrastructure.Factory.AppContext
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext CreateContext()
        {
            var connectionString = new ConfigurationFixture().Value.DbConnectionString;

            return new ApplicationDbContext(connectionString);
        }
    }
}
