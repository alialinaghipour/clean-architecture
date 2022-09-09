using ApplicationContracts.Contracts;
using ApplicationContracts.Members.Dto;

namespace ApplicationServices.Members;

public class MemberAppService : IMemberService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemberRepository _repository;

    public MemberAppService(
        IUnitOfWork unitOfWork,
        IMemberRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task Create(CreateMemberDto dto)
    {
        var member = new Member()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

         _repository.Add(member);
    }
}