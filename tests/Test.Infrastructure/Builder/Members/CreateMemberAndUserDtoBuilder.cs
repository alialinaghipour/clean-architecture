using ApplicationHandlerContracts.CreateMemberAndUser;
using Test.Infrastructure.Factory.Dummies;

namespace Test.Infrastructure.Builder.Members;

public class CreateMemberAndUserDtoBuilder
{
    private readonly CreateMemberAndUserDto _dto;

    public CreateMemberAndUserDtoBuilder()
    {
        _dto = new CreateMemberAndUserDto
        {
            Email = DummyFactory.GenerateDummyString()+"@gmail.com",
            FirstName = DummyFactory.GenerateDummyString(),
            LastName = DummyFactory.GenerateDummyString(),
        };
    }

    public CreateMemberAndUserDtoBuilder WithEmail(string email)
    {
        _dto.Email = email;
        return this;
    }

    public CreateMemberAndUserDto Build()
    {
        return _dto;
    }
}