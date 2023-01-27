using SendGrid;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using SendGrid.Helpers.Mail;

public class EmailService : IIdentityMessageService
{
    public async Task SendAsync(IdentityMessage message)
    {
        await configSendGridasync(message);
    }

    // Use NuGet to install SendGrid (Basic C# client lib) 
    private async Task configSendGridasync(IdentityMessage message)
    {
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("Library");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("chusiying@outlook.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("chusiying@outlook.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
