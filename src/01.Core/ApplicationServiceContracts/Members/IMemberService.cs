using ApplicationContracts.Contracts;
using ApplicationContracts.Members.Dto;

namespace ApplicationContracts.Members;

public interface IMemberService : IScoped
{
    Task Create(CreateMemberDto dto);
}