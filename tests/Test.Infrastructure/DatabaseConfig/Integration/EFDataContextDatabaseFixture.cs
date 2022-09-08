using Persistence.Ef;
using Xunit;

namespace Test.Infrastructure.DatabaseConfig.Integration;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    private readonly ConfigurationFixture _configuration;

    public EFDataContextDatabaseFixture(ConfigurationFixture configuration)
    {
        _configuration = configuration;
    }

    public ApplicationDbContext CreateDataContext()
    {
        return new ApplicationDbContext(_configuration.Value.DbConnectionString);
    }
}