
namespace ApplicationContracts.Identity.Dto;

public class RegisterApplicationUserDto
{
    [Required] public string Password { get; set; } = default!;

    [Required] public string UserName { get; set; } = default!;
}