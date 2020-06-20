using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using AzCloudApp.MessageProcessor.Core.ThermoDataModel.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private NotificationConfiguration _notificationConfiguration;

        public SendMailService(ILogger<SendMailService> logger, IOptions<NotificationConfiguration> notificationConfiguration)
        {
            _logger = logger;
            _notificationConfiguration = notificationConfiguration.Value;
        }

        public async Task<int> SendMailAsync(AttendRecord record)
        {
            await this.SendMailAsync();
            return 1;
        }

        private Task SendMailAsync()
        { 
            this._logger.LogInformation($"Sending email : {this._notificationConfiguration.SmtpServer}");

            MailMessage mail = new MailMessage();
            SmtpClient mailClient = new SmtpClient(this._notificationConfiguration.SmtpServer);

            mail.From = new MailAddress("jerwonzaks@gmail.com");
            mail.To.Add("kepung@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";

            mailClient.Port = 587;
            mailClient.Credentials = new System.Net.NetworkCredential(
                this._notificationConfiguration.Username,
                this._notificationConfiguration.Password);
            
            mailClient.EnableSsl = true;
            mailClient.SendAsync(mail, new object());

            return Task.CompletedTask;
        }
    }
}