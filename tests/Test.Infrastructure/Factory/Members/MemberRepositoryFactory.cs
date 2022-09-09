using ApplicationContracts.Members;
using Domain.Members;
using Moq;
using Persistence.Ef;
using Persistence.Ef.Members;

namespace Test.Infrastructure.Factory.Members;

public static class MemberRepositoryFactory
{
    public static IMemberRepository Create(ApplicationDbContext context)
    {
        return new EfMemberRepository(context);
    }
    
    public static Mock<IMemberRepository> CreateMock()
    {
        return new Mock<IMemberRepository>();
    }

    public static void SetupAddMember(
        this Mock<IMemberRepository> memberRepositoryMock,
        string id,
        string firstName,
        string lastName)
    {
        memberRepositoryMock.Setup(_ => _.Add(new Member
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        }));
    }

    public static void VerifyAddMember(
        this Mock<IMemberRepository> memberRepositoryMock,
        string id,
        string firstName,
        string lastName)
    {
        memberRepositoryMock.Verify(_=>_
            .Add(It.Is<Member>(member => 
                member.Id == id &&
                member.FirstName == firstName &&
                member.LastName == lastName)));
    }
}