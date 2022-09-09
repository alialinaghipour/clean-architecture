using System.ComponentModel.DataAnnotations;

namespace ApplicationHandlerContracts.UserLogin;

public class UserLoginDto
{
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; } = default!;
    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = default!;
    [Required]
    [MaxLength(50)]
    [Compare(nameof(Password))]
    public string RepeatPassword { get; set; } = default!;
}