using MimeKit;

namespace ERMAN.Services
{
    public interface IEmailServices
    {
        public void SendEmail(MimeMessage email);
    }
}
