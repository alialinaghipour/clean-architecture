namespace Identity.Dto;

public class UserChangePasswordDto
{
    [Required] public string CurrentPassword { get; set; } = default!;

    [Required] public string NewPassword { get; set; } = default!;

    [Required]
    [Compare("NewPassword")]
    public string ConfirmNewPassword { get; set; } = default!;
}