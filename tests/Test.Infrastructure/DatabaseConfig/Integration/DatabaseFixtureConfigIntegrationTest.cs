using Persistence.Ef;
using Test.Infrastructure.DatabaseConfig.Unit;

namespace Test.Infrastructure.DatabaseConfig.Integration;

public class DatabaseFixtureConfigIntegrationTest : EFDataContextDatabaseFixture
{
    private readonly ApplicationDbContext _actContext;
    private readonly ApplicationDbContext _arrangeContext;
    private readonly ApplicationDbContext _assertDataContext;
    
    protected DatabaseFixtureConfigIntegrationTest(ConfigurationFixture configuration) 
        : base(configuration)
    {
        _actContext = CreateDataContext();
        _arrangeContext = CreateDataContext();
        _assertDataContext = CreateDataContext();
    }
    
    protected ApplicationDbContext ArrangeContext()
    {
        return _arrangeContext;
    }

    protected ApplicationDbContext ActContext()
    {
        return _actContext;
    }

    protected ApplicationDbContext AssertContext()
    {
        return _assertDataContext;
    }

    protected void Save<T>(T entity) where T : class, new()
    {
        _arrangeContext.Save(entity);
    }

    protected void Save<T>(params T[] entities) where T : class, new()
    {
        foreach (var entity in entities)
            _arrangeContext.SaveRange(entity);
    }
}