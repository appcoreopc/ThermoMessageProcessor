using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ThemoDataMessageProcessor.PersonelThemoDataHandler;


namespace PersonelTemperatureHandlingFunction
{
    public class PersonelTemperatureHandlingFunction
    {
        //private readonly IMesssageThermoProcessor _messsageThermoProcessor;
        //public PersonelTemperatureHandlingFunction(IMesssageThermoProcessor messsageThermoProcessor)
        //{
        //    this._messsageThermoProcessor = messsageThermoProcessor;
        //}

        public PersonelTemperatureHandlingFunction()
        {
            //this._messsageThermoProcessor = messsageThermoProcessor;
        }

        [FunctionName("PersonelThermoFunction")]
        public static void Run([ServiceBusTrigger("devsbqbank", 
            Connection = "sbqconnection")]string messageSource, 
            ILogger log)
        {
            _ = new PersonelThermoMessageProcessor(log).ProcessMessage(messageSource);
            log.LogInformation("v2 : PersonelThermoFunction");
        }
    }
}
