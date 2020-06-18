using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThemoDataMessageProcessor.DataProcessor;
using ThemoDataMessageProcessor.PersonelThemoDataHandler;
using ThermoDataStore;

[assembly: FunctionsStartup(typeof(ThermoDataMessageSender.Startup))]

namespace ThermoDataMessageSender
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
