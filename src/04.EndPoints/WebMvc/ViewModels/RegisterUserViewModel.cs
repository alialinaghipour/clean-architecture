using System.ComponentModel.DataAnnotations;

namespace WebMvc.ViewModels;

public class RegisterViewModel
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = default!;
    [Display]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
    [Display]
    [DataType(DataType.Password)]
    [Required]
    [Compare(nameof(DataType.Password))]
    public string ConfirmPassword { get; set; } = default!;
    [Display]
    [DataType(DataType.EmailAddress)]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;
}