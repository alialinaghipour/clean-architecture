using ApplicationHandlerContracts.UserLogin;

namespace Test.IntegrationHandlers;

public class UserFixture : IDisposable
{
    protected readonly ApplicationDbContext Context;
    protected IUserLoginAndCreateTokenServiceHandler LoginAndCreateTokenServiceHandler;
    protected readonly ICreateMemberAndUserHandler CreateMemberAndUserHandler;

    protected UserFixture(
        ApplicationDbContext context,
        ICreateMemberAndUserHandler createMemberAndUserHandler)
    {
        Context = context;
        CreateMemberAndUserHandler = createMemberAndUserHandler;
    }
    
    protected UserFixture(
        ApplicationDbContext context,
        IUserLoginAndCreateTokenServiceHandler loginAndCreateTokenServiceHandler)
    {
        Context = context;
        LoginAndCreateTokenServiceHandler = loginAndCreateTokenServiceHandler;
    }

    public void Dispose()
    {
        var users = Context.Users.ToList();
        var members = Context.Set<Member>().ToList();

        users
            .ForEach(_ => Context.Entry(_).State = EntityState.Deleted);
        members
            .ForEach(_ => Context.Entry(_).State = EntityState.Deleted);

        Context.SaveChanges();
    }
}