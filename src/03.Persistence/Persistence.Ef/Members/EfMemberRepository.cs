using ApplicationContracts.Members;
using Domain.Members;

namespace Persistence.Ef.Members;

public class EfMemberRepository : IMemberRepository
{
    private readonly DbSet<Member> _members;
    public EfMemberRepository(ApplicationDbContext context)
    {
        _members = context.Set<Member>();
    }
    
    public void Add(Member member)
    {
        _members.Add(member);
    }
}