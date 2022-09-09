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
}