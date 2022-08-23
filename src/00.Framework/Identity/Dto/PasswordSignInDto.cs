namespace Identity.Dto;

public class PasswordSignInDto
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool RememberMe { get; set; }
    public bool LockoutOnFailure { get; set; }
}