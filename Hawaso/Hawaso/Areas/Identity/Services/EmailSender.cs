using Microsoft.AspNetCore.Identity.UI.Services;

namespace Hawaso.Areas.Identity.Services
{
    // Abstractions: Interfaces => IEmailSender
    // Implementations: Classes => EmailSender, SendGridEmailSender, ...
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
