namespace WebMvc.Areas.UserPanel.Models;

public class InformationViewModel
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string RegisterDate { get; set; } = default!;
    public int Wallet { get; set; }
}