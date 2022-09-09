using System.Transactions;

namespace Test.Infrastructure.DatabaseConfig.Integration;

public class DatabaseFixture : IDisposable
{
    private readonly TransactionScope _transactionScope;

    protected DatabaseFixture()
    {
        _transactionScope = new TransactionScope(
            TransactionScopeOption.Required,
            TransactionScopeAsyncFlowOption.Enabled);
    }

    public virtual void Dispose()
    {
        _transactionScope?.Dispose();
    }
}