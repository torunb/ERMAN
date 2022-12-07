using MailKit.Net.Smtp;
using MimeKit;

namespace ERMAN.Services
{
    public class EmailService : IEmailServices
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(MimeMessage email)
        {
            using var smtp = new SmtpClient();

            smtp.Connect(_config["Email:Host"], int.Parse(_config["Email:Port"]), true);

            smtp.Authenticate(_config["Email:Username"], _config["Email:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
