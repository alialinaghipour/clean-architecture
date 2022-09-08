using Persistence.Ef;

namespace Test.Infrastructure.Database;

public abstract class BasicUnitTest
{
    private readonly ApplicationDbContext _actContext;
    private readonly ApplicationDbContext _arrangeContext;
    private readonly ApplicationDbContext _assertDataContext;

    protected BasicUnitTest()
    {
        var db = new EfInMemoryDatabase();
        _arrangeContext = db.CreateDataContext<ApplicationDbContext>();
        _actContext = db.CreateDataContext<ApplicationDbContext>();
        _assertDataContext = db.CreateDataContext<ApplicationDbContext>();
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

    public void Save()
    {
        _arrangeContext.SaveChanges();
    }
}