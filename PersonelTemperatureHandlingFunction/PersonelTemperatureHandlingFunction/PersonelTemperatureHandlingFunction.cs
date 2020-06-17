using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
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

        [FunctionName("PersonelThermoFunction")]
        public async Task Run([ServiceBusTrigger("devsbqbank", 
            Connection = "sbqconnection")]string messageSource, ILogger log)
        {
            this._logger.LogInformation($"injected logger(l): {messageSource}");
            await this._messsageThermoProcessor.ProcessMessage(messageSource);
        }
    }
}
