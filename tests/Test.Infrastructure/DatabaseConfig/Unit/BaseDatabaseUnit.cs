using Persistence.Ef;

namespace Test.Infrastructure.DatabaseConfig.Unit;

public abstract class DatabaseConfigUnitTest
{
    private readonly ApplicationDbContext _setupContext;
    private readonly ApplicationDbContext _arrangeContext;
    private readonly ApplicationDbContext _assertDataContext;

    protected DatabaseConfigUnitTest()
    {
        var db = new EfInMemoryDatabase();
        _arrangeContext = db.CreateDataContext<ApplicationDbContext>();
        _setupContext = db.CreateDataContext<ApplicationDbContext>();
        _assertDataContext = db.CreateDataContext<ApplicationDbContext>();
    }

    protected ApplicationDbContext ArrangeContext()
    {
        return _arrangeContext;
    }

    protected ApplicationDbContext SetupContext()
    {
        return _setupContext;
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

    public void Save()
    {
        _arrangeContext.SaveChanges();
    }
}