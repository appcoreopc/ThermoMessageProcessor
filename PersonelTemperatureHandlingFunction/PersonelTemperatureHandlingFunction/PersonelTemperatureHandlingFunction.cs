using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ThemoDataMessageProcessor.DataProcessor;
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

        [FunctionName("PersonelThermoFunction_l")]
        public async Task Run([ServiceBusTrigger("devsbqbank", 
            Connection = "sbqconnection")]string messageSource, ILogger log)
        {
            log.LogInformation($"function logger(l): {messageSource}");
            this._logger.LogInformation($"injected logger(l): {messageSource}");

            await new PersonelThermoMessageProcessor(log, new MessageController(log)).ProcessMessage(messageSource);

            await this._messsageThermoProcessor.ProcessMessage(messageSource);
        }
    }
}
