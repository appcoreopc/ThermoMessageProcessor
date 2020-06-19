using AzCloudApp.MessageProcessor.Core.DataProcessor;
using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.PersonelThemoDataHandler
{
    public class PersonelThermoMessageProcessor : IMesssageThermoProcessor
    {
        private readonly ILogger<PersonelThermoMessageProcessor> _logger;
        private readonly IMessageController _messageController;

        public PersonelThermoMessageProcessor(ILogger<PersonelThermoMessageProcessor> logger,
          IMessageController messageController)
        {
            _logger = logger;
            _messageController = messageController;
        }
        public Task ProcessMessage(string message)
        {
            this._logger.LogInformation($"Processing message using PersonelThermoMessageProcessor :{DateTime.Now} : {message}");
            this._messageController.ProcessDataAsync(message);
            return Task.CompletedTask;
        }
    }
}
