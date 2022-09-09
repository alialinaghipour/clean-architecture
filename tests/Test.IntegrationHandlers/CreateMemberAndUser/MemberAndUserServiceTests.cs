using ApplicationHandlerContracts.UserLogin;
using Test.Infrastructure.Builder.Identity;
using Test.Infrastructure.DatabaseConfig.Unit;

namespace Test.IntegrationHandlers.CreateMemberAndUser;

[Collection(nameof(UserFixture))]
public class MemberAndUserServiceTests : UserFixture
{
    public MemberAndUserServiceTests(
        ApplicationDbContext context,
        ICreateMemberAndUserHandler createMemberAndUserHandler) 
        : base(
            context,
            createMemberAndUserHandler)
    {
    }

    [Fact]
    public async Task CreateMemberAndUser_create_employee_properly()
    {
        var dto = new CreateMemberAndUserDtoBuilder()
            .Build();

        await CreateMemberAndUserHandler.Create(dto);

        var expected = await Context.Set<Member>().SingleAsync();
        expected.FirstName.Should().Be(dto.FirstName);
        expected.LastName.Should().Be(dto.LastName);
        expected.Email.Should().Be(dto.Email);
    }

    [Fact]
    public async Task CreateMemberAndUser_create_user_properly()
    {
        var dto = new CreateMemberAndUserDtoBuilder()
            .Build();

        await CreateMemberAndUserHandler.Create(dto);

        var expected = await Context.Users.SingleAsync();
        expected.UserName.Should().Be(dto.Email);
        expected.Email.Should().Be(dto.Email);
        expected.EmailConfirmed.Should().BeFalse();
    }

    [Fact]
    public async Task
        CreateMemberAndUser_throw_exception_when_email_duplicate()
    {
        var user = new UserBuilder().Build();
        Context.Save(user);
        var dto = new CreateMemberAndUserDtoBuilder()
            .WithEmail(user.Email)
            .Build();

        var expected = async () => await CreateMemberAndUserHandler.Create(dto);

        await expected.Should()
            .ThrowExactlyAsync<FailedCreateMemberAndUserDtoException>();
    }
}