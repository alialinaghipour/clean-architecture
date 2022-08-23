namespace ApplicationContracts.Contracts;

public interface IUnitOfWork
{
    Task Begin();
    Task Commit();
    Task Rollback();
    Task Complete();
}