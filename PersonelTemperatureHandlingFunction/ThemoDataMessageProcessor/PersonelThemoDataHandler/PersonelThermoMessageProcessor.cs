﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using ThemoDataMessageProcessor.DataProcessor;
using ThemoDataModel;

namespace ThemoDataMessageProcessor.PersonelThemoDataHandler
{
    public class PersonelThermoMessageProcessor : IMesssageThermoProcessor
    {
        private readonly ILogger _logger;
        private readonly IMessageController _messageController;

        public PersonelThermoMessageProcessor(ILogger logger,
          IMessageController messageController)
        {
            _logger = logger;
            _messageController = messageController;
        }
        public Task ProcessMessage(string message)
        {
            this._logger.LogInformation($"Processing message using PersonelThermoMessageProcessor  {DateTime.Now} : {message}");

            var targetData = JsonConvert.DeserializeObject<PersonelThermoDataModel>(message);
            this._messageController.ProcessDataAsync(targetData);
            return Task.CompletedTask;
        }
    }
}
