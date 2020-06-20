using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using AzCloudApp.MessageProcessor.Core.Utils;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class NotificationMessageProcessor 
        : INotificationProcessor
    {
        public float SafeBodyTemperature { get; set; }

        private readonly ISendMailService _sendMailService;
        public NotificationMessageProcessor(ISendMailService sendMail)
        {
            this._sendMailService = sendMail;
        }

        public Task<int> ProcessAsync(string source)
        {

            this._sendMailService.SendMailAsync(new AttendRecord());

            //var target = MessageConverter.GetMessageType<AttendRecord>(source);

            //if (target.BodyTemperature.GetFloatValue() > SafeBodyTemperature)
            //{
            //    _sendMailService.SendMailAsync(target);
            //}
            return Task.FromResult(1);
        }
    }
}
