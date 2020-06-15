using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace ThemoDataMessageProcessor.PersonelThemoDataHandler
{
    public class PersonelThermoMessageProcessor : IMesssageThermoProcessor
    {
        private readonly ILogger _logger;
        public PersonelThermoMessageProcessor(ILogger logger)
        {
            _logger = logger;
        }
        public T ProcessMessage<T>(string message)
        {
            this._logger.LogInformation($"Processing message at {DateTime.Now} : {message}");
            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
