using ApplicationContracts.Members;
using ApplicationServices.Members;
using Persistence.Ef;
using Test.Infrastructure.Factory.UnitOfWork;

namespace Test.Infrastructure.Factory.Members;

public static class MemberServiceFactory
{
    public static IMemberService Create(ApplicationDbContext context)
    {
        var memberRepository = MemberRepositoryFactory.Create(context);
        var uintOfWork = UnitOfWorkFactory.Create(context);

        return new MemberAppService(
            uintOfWork,
            memberRepository);
    }
    
    public static IMemberService Create(
        ApplicationDbContext context,
        IMemberRepository memberRepository)
    {
        var uintOfWork = UnitOfWorkFactory.Create(context);

        return new MemberAppService(
            uintOfWork,
            memberRepository);
    }
}