using ApplicationContracts.Contracts;

namespace ApplicationHandlerContracts.CreateMemberAndUser;

public interface ICreateMemberAndUserHandler : IScoped
{
    Task Create(CreateMemberAndUserDto dto);
}