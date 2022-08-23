namespace WebMvc.ViewModels;

public class GetEmailViewModel
{
    public GetEmailViewModel(string email)
    {
        Email = email;
    }
    public string Email { get; set; }
}