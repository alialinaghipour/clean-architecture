using Persistence.Ef;
using Test.Infrastructure.DatabaseConfig.Unit;

namespace Test.Infrastructure.DatabaseConfig.Integration;

public class BaseDatabaseIntegration : EFDataContextDatabaseFixture
{
    private readonly ApplicationDbContext _setupDbContext;
    private readonly ApplicationDbContext _arrangeDbContext;
    private readonly ApplicationDbContext _assertDbContext;
    
    protected BaseDatabaseIntegration(ConfigurationFixture configuration) 
        : base(configuration)
    {
        _setupDbContext = CreateDataContext();
        _arrangeDbContext = CreateDataContext();
        _assertDbContext = CreateDataContext();
    }
    
    protected ApplicationDbContext ArrangeContext()
    {
        return _arrangeDbContext;
    }

    protected ApplicationDbContext SetupContext()
    {
        return _setupDbContext;
    }

    protected ApplicationDbContext AssertContext()
    {
        return _assertDbContext;
    }

    protected void Save<T>(T entity) where T : class, new()
    {
        _arrangeDbContext.Save(entity);
    }

    protected void Save<T>(params T[] entities) where T : class, new()
    {
        foreach (var entity in entities)
            _arrangeDbContext.SaveRange(entity);
    }
}