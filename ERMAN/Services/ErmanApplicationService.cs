using MimeKit;

namespace ERMAN.Services
{
    public class ErmanApplicationService
    {
        private readonly IEmailServices _emailServices;
        private readonly ErmanDbContext _context; // to have access to the tables in the database
        private readonly IConfiguration _config;

        public ErmanApplicationService(IEmailServices emailServices, ErmanDbContext context, IConfiguration config)
        {
            _emailServices = emailServices;
            _context = context;
            _config = config;
        }

        public void SendUserInformation(string to)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_config["Email:Username"], _config["Email:Username"]));
            email.To.Add(MailboxAddress.Parse(to));

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) // username and password will be given
            {
                Text = @"<!DOCTYPE html>
                    <html>

                    <body>

                    <p>Welcome to the ERMAN! Your login information is the following, <br>
                        Username: <br>
                        Password: </p>

                    </body>
                    </html>"
            };

            _emailServices.SendEmail(email);
        }
    }
}
