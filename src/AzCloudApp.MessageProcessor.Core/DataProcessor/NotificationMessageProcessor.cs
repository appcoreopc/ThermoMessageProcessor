using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using AzCloudApp.MessageProcessor.Core.Utils;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class NotificationMessageProcessor : INotificationProcessor
    {
        private readonly float _safeBodyTemperate;
        private readonly ISendMailService _sendMailService;
        public NotificationMessageProcessor(ISendMailService sendMail, float safeBodyTemperate = 37)
        {
            _safeBodyTemperate = safeBodyTemperate;
            this._sendMailService = sendMail;
        }

        public Task<int> ProcessAsync(string source)
        {
            var target = MessageConverter.GetMessageType<AttendRecord>(source);

            if (target.BodyTemperature.GetFloatValue() > _safeBodyTemperate)
            {
                _sendMailService.SendMailAsync(target);
            }
            return Task.FromResult(1);
        }
    }
}
