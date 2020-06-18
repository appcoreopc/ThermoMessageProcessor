using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ThemoDataMessageProcessor.PersonelThemoDataHandler;

namespace PersonelTemperatureHandlingFunction
{
    public class PersonelTemperatureHandlingFunction
    {
        private readonly IMesssageThermoProcessor _messsageThermoProcessor;
        private readonly ILogger<PersonelTemperatureHandlingFunction> _logger;

        public PersonelTemperatureHandlingFunction(ILogger<PersonelTemperatureHandlingFunction> logger, IMesssageThermoProcessor messsageThermoProcessor)
        {
            this._messsageThermoProcessor = messsageThermoProcessor;
            this._logger = logger;
        }

        [FunctionName("ThermoDataProcessorAzure")]
        public async Task Run([ServiceBusTrigger("devsbqbank", 
            Connection = "sbqconnection")]string messageSource, ILogger log)
        {
            this._logger.LogInformation($"ThermoDataProcessorAzure Logger: {messageSource} {DateTime.Now}");
            await this._messsageThermoProcessor.ProcessMessage(messageSource);
        }
    }
}
