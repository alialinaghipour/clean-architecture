namespace ApplicationContracts.Contracts.Sender;

public class SendEmailDto
{
    public string ToEmail { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string? Body { get; set; } = default!;
    public bool IsBodyHtml { get; set; } = false;
}