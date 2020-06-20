using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public interface ISendMailService
    {
        Task<int> SendMailAsync(AttendRecord record); 
    }

    public class SendMailService : ISendMailService
    {
        private ILogger<SendMailService> _logger;

        public SendMailService(ILogger<SendMailService> logger)
        {
            _logger = logger;
        }

        public async Task<int> SendMailAsync(AttendRecord record)
        {
            await this.SendMailAsync();
            return 1;
        }

        private Task SendMailAsync()
        { 
            this._logger.LogInformation("Sending email. smtp-relay.gmail.com");

            MailMessage mail = new MailMessage();
            SmtpClient mailClient = new SmtpClient("smtp-relay.gmail.com");

            mail.From = new MailAddress("jerwonzaks@gmail.com");
            mail.To.Add("kepung@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";

            mailClient.Port = 587;
            mailClient.Credentials = new System.Net.NetworkCredential("jerwonzaks@gmail.com", "!0nicFrame");
            mailClient.EnableSsl = true;
            mailClient.SendAsync(mail, new object());

            return Task.CompletedTask;
        }
    }
}