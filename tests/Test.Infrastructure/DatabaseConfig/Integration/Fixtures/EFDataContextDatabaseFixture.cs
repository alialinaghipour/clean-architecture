using Persistence.Ef;
using Xunit;

namespace Test.Infrastructure.DatabaseConfig.Integration;

[Collection(nameof(ConfigurationFixture))]
public class ApplicationDbContextDatabaseFixture : DatabaseFixture
{
    private readonly ConfigurationFixture _configuration;

    protected ApplicationDbContextDatabaseFixture(ConfigurationFixture configuration)
    {
        _configuration = configuration;
    }

    protected ApplicationDbContext CreateDataContext()
    {
        return new ApplicationDbContext(_configuration.Value.DbConnectionString);
    }
}