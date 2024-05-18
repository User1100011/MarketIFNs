using Market.Models.Entityes;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Market.Services.OtherServices
{
    public class EmailSenderService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient { EnableSsl = true };
            await smtpClient.SendMailAsync(
                new MailMessage("amirlegenda69@gmail.com", email));
        }
    }
}
