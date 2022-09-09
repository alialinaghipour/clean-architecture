using ApplicationContracts.Members;
using Test.Infrastructure.Builder.Members;
using Test.Infrastructure.DatabaseConfig.Unit;
using Test.Infrastructure.DummyData;
using Test.Infrastructure.Factory.Members;

namespace Test.Unit.Repositories.Members;

public class MemberRepositoryTests : BasicUnitTest
{
    private readonly IMemberRepository _repository;
    public MemberRepositoryTests()
    {
        _repository=MemberRepositoryFactory.Create(ActContext());
    }
    [Theory]
    [DummyThreeString]
    public void Add_add_properly(
        string id,
        string firstName,
        string lastName)
    {
        var member = new MemberBuilder()
            .WithId(id)
            .WithFirstName(firstName)
            .WithLastName(lastName)
            .Build();

        
    }
}