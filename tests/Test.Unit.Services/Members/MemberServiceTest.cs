using Test.Infrastructure.DatabaseConfig.Unit;
using Test.Infrastructure.DummyData;
using Test.Infrastructure.Factory.Members;
using Test.Infrastructure.Factory.Members.Dto;
using Xunit;

namespace Test.Unit.Services.Members;

public class MemberServiceTest : DatabaseConfigUnitTest
{
    [Theory]
    [DummyThreeString]
    public void Create_create_member_properly(
        string id,
        string firstName,
        string lastName)
    {
        var repository = MemberRepositoryFactory.CreateMock();
        var dto = CreateMemberDtoFactory.Generate(id,firstName, lastName);
        repository.SetupAddMember(id,firstName,lastName);
        var sut = MemberServiceFactory.Create(ActContext(), repository.Object);

        sut.Create(dto);
        
        repository.VerifyAddMember(id,firstName,lastName);
    }
}