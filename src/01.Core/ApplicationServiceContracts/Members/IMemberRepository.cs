using ApplicationContracts.Contracts;

namespace ApplicationContracts.Members;

public interface IMemberRepository : IScoped
{
    void Add(Member member);
}