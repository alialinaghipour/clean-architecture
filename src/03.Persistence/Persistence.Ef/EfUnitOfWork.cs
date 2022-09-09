namespace Persistence.Ef;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dataContext;

    public EfUnitOfWork(ApplicationDbContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task BeginTransaction()
    {
        await _dataContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        await _dataContext.SaveChangesAsync();
        await _dataContext.Database.CommitTransactionAsync();
    }

    public async Task Complete()
    {
        await _dataContext.SaveChangesAsync();
    }

    public async Task RollbackTransaction()
    {
        await _dataContext.Database.RollbackTransactionAsync();
    }

    public async Task CommitPartial()
    {
        await _dataContext.SaveChangesAsync();
    }
}