using ApplicationContracts.Contracts;
using Persistence.Ef;

namespace Test.Infrastructure.Factory.UnitOfWork;

public static class UnitOfWorkFactory
{
    public static IUnitOfWork Create(ApplicationDbContext context)
    {
        return new EfUnitOfWork(context);
    }
}