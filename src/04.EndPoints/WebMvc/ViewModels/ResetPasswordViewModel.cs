using System.ComponentModel.DataAnnotations;

namespace WebMvc.ViewModels;

public class ResetPasswordViewModel
{
    public string UserName { get; set; } = default!;
    public string SecurityStamp { get; set; } = default!;

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200,
        ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Password { get; set; } = default!;

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200,
        ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
    public string RePassword { get; set; } = default!;
}