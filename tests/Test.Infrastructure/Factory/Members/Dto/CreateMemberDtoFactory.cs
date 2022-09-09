using ApplicationContracts.Members;
using ApplicationContracts.Members.Dto;

namespace Test.Infrastructure.Factory.Members.Dto;

public static class CreateMemberDtoFactory
{
    public static CreateMemberDto Generate(
        string id,
        string firstName,
        string lastName)
    {
        return new CreateMemberDto
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };
    }
}