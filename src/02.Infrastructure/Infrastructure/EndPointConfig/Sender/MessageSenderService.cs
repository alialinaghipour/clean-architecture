using System.Net;
using System.Net.Mail;
using ApplicationContracts.Contracts.Sender;

namespace Infrastructure.EndPointConfig.Sender;

public class MessageSenderAppService : IMessageSenderService
{
    public Task SendEmail(SendEmailDto dto)
    {
        using (var client = new SmtpClient())
        {
            var credentials = new NetworkCredential
            {
                UserName = "systaav",
                Password = "dummy"
            };

            client.Credentials = credentials;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;

            using var emailMessage = new MailMessage
            {
                To = {new MailAddress(dto.ToEmail)},
                From = new MailAddress("systaav@gmail.com"),
                Subject = dto.Subject,
                Body = dto.Body,
                IsBodyHtml = dto.IsBodyHtml
            };

            client.Send(emailMessage);
        }

        return Task.CompletedTask;
    }
}