namespace ApplicationContracts.Contracts;

public interface IUnitOfWork : IScoped
{
    Task BeginTransaction();
    Task CommitTransaction();
    Task CommitPartial();
    Task RollbackTransaction();
    Task Complete();
}