using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ThemoDataMessageProcessor.PersonelThemoDataHandler;

namespace PersonelTemperatureHandlingFunction
{
    public static class PersonelTemperatureHandlingFunction
    {
        //ßprivate readonly IMesssageThermoProcessor _messsageThermoProcessor;
        //public PersonelTemperatureHandlingFunction(IMesssageThermoProcessor messsageThermoProcessor)
        //{
        //    this._messsageThermoProcessor = messsageThermoProcessor;
        //}

        [FunctionName("PersonelThermoFunction")]
        public  static void Run([ServiceBusTrigger("devsbqbank", 
            Connection = "sbqconnection")]string messageSource, 
            ILogger log)
        {

            log.LogInformation($"{messageSource}");
        }
    }
}
