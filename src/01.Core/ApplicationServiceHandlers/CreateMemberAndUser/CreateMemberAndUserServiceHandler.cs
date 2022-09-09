using ApplicationContracts.Contracts;
using ApplicationContracts.Members;
using ApplicationContracts.Members.Dto;
using ApplicationHandlerContracts.CreateMemberAndUser;
using Identity;

namespace ApplicationServiceHandlers.CreateMemberAndUser;

public class CreateMemberAndUserServiceHandler : ICreateMemberAndUserHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserManagementService _userManagementService;
    private readonly IMemberService _memberService;
    private readonly IGenerateCodeService _generateCodeService;

    public CreateMemberAndUserServiceHandler(
        IUnitOfWork unitOfWork,
        IUserManagementService userManagementService,
        IMemberService memberService,
        IGenerateCodeService generateCodeService)
    {
        _unitOfWork = unitOfWork;
        _userManagementService = userManagementService;
        _memberService = memberService;
        _generateCodeService = generateCodeService;
    }
    
    public async Task Create(CreateMemberAndUserDto dto)
    {
        await _unitOfWork.BeginTransaction();
        try
        {
            var user = await CreateUser(dto);
            await CreateMember(dto, user.Id);
            await _unitOfWork.CommitTransaction();
        }
        catch
        {
            await _unitOfWork.RollbackTransaction();
            throw new FailedCreateMemberAndUserDtoException();
        }
    }

    private async Task CreateMember(CreateMemberAndUserDto dto, string id)
    {
        var createMemberDto = new CreateMemberDto
        {
            Id = id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
        };
        await _memberService.Create(createMemberDto);
    }

    private async Task<User> CreateUser(CreateMemberAndUserDto dto)
    {
        var user = new User
        {
            Id = _generateCodeService.UniqueCode(),
            Email = dto.Email,
            UserName = dto.Email,
            EmailConfirmed = false
        };
        await _userManagementService.Create(
            user,
            password: user.Email);
        return user;
    }
}