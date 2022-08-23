using System.ComponentModel.DataAnnotations;

namespace WebMvc.ViewModels;

public class LoginUserViewModel
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200,
        ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string UserName { get; set; } = default!;

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Password { get; set; } = default!;

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }
}