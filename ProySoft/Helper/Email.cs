using ProySoft.Helper.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace ProySoft.Helper
{
    public class Email : IEmail
    {
        public Email(IConfiguration configuration)
        {
            _config = configuration;
        }
        public IConfiguration _config;

        public async Task SendEmailWithTemplateAsync(string ToEmail)
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var message = $"{random.Next(0, 5)}";
            var subject = "Cupon";
            await SendEmailAsync(ToEmail, subject, message);
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            var client = new SendGridClient("SG.dhHV1 - EiSFyThldkCjnaOA._00L0cQ6jxIOaC3VBnKNT - JojBcS - rsfwbrU35NVuF8");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("McDonalds@ronald.com"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
