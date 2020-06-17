using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ThemoDataMessageProcessor.PersonelThemoDataHandler;
using ThemoDataMessageProcessor.DataProcessor;

[assembly: FunctionsStartup(typeof(PersonelTemperatureHandlingFunction.Startup))]

namespace PersonelTemperatureHandlingFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddTransient<IMesssageThermoProcessor, PersonelThermoMessageProcessor>();
            builder.Services.AddTransient<IMessageController, MessageController>();
        }
    }
}
