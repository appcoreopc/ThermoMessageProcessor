using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace AzCloudApp.Notification.Function
{
    public class MessageToEmailNotificationFunction
    {
        private readonly ILogger<MessageToEmailNotificationFunction> _logger;

        public MessageToEmailNotificationFunction(ILogger<MessageToEmailNotificationFunction> logger)
        {
            this._logger = logger;

        }

        [FunctionName("MessageToEmailNotificationFunction")]
        public void Run([ServiceBusTrigger("sbqmail", Connection = "MailingQueueConnection")] string messageSource)
        {
            this._logger.LogInformation($"ThermoDataProcessorAzure started : {messageSource} {DateTime.Now}");
            //await this._messsageThermoProcessor.ProcessMessage(messageSource);
        }
    }
}
