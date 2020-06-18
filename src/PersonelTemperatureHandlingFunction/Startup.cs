using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ThemoDataMessageProcessor.PersonelThemoDataHandler;
using ThemoDataMessageProcessor.DataProcessor;
using Microsoft.EntityFrameworkCore;
using ThermoDataStore;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(PersonelTemperatureHandlingFunction.Startup))]

namespace PersonelTemperatureHandlingFunction
{
    public class Startup : FunctionsStartup
    {
        public Startup()
        {
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {

            var config = new ConfigurationBuilder()
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

            builder.Services.AddLogging();

            builder.Services.AddSingleton<IDataStoreProcesor, DataStoreMessageProcessor>();
            builder.Services.AddSingleton<INotificationProcesor, NotificationMessageProcessor>();

            builder.Services.AddSingleton<IMessageController, MessageController>();
            builder.Services.AddTransient<IMesssageThermoProcessor, PersonelThermoMessageProcessor>();

            builder.Services.AddDbContext<ThermoDataContext>(opt => opt.UseSqlServer(config.GetConnectionString("ThermoDatabase")));
        }
    }
}
