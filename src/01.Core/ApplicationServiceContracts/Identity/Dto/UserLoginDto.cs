namespace ApplicationContracts.Identity.Dto;

public class UserLoginDto
{
    [Required] public string UserName { get; set; } = default!;

    [Required] public string Password { get; set; } = default!;
}