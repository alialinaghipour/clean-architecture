namespace ApplicationContracts.Contracts.Sender;

public interface IMessageSenderService
{
    Task SendEmail(SendEmailDto dto);
}