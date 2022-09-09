using Domain.Members;
using Test.Infrastructure.Factory.Dummies;

namespace Test.Infrastructure.Builder.Members;

public class MemberBuilder
{
    private readonly Member _member;

    public MemberBuilder()
    {
        _member = new Member
        {
            Id = DummyFactory.GenerateDummyString(),
            FirstName = DummyFactory.GenerateDummyString(),
            LastName = DummyFactory.GenerateDummyString(),
            Email = DummyFactory.GenerateDummyString()
        };
    }

    public MemberBuilder WithId(string id)
    {
        _member.Id = id;
        return this;
    }

    public MemberBuilder WithLastName(string lastName)
    {
        _member.LastName = lastName;
        return this;
    }

    public MemberBuilder WithFirstName(string firstName)
    {
        _member.FirstName = firstName;
        return this;
    }

    public Member Build()
    {
        return _member;
    }
}