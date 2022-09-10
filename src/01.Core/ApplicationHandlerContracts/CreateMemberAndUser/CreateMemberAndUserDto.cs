using System.ComponentModel.DataAnnotations;

namespace ApplicationHandlerContracts.CreateMemberAndUser;

public class CreateMemberAndUserDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = default!;
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; } = default!;
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = default!;
    [DataType(DataType.Password)]
    [Required]
    [Compare(nameof(DataType.Password))]
    public string ConfirmPassword { get; set; } = default!;
}