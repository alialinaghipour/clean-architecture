using System.ComponentModel.DataAnnotations;

namespace WebMvc.ViewModels;

public class LoginViewModel
{
    [Display]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
    [Display]
    [Required]
    public string Email { get; set; } = default!;
    public string? ReturnUrl { get; set; }
}