using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AzCloudApp.MessageProcessor.Core.DataProcessor;
using AzCloudApp.MessageProcessor.Core.Thermo.DataStore;
using AzCloudApp.MessageProcessor.Core.PersonelThemoDataHandler;

[assembly: FunctionsStartup(typeof(AzCloudApp.MessageProcessor.Function.Startup))]

namespace AzCloudApp.MessageProcessor.Function
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
            builder.Services.AddSingleton<INotificationProcessor, NotificationMessageProcessor>();

            builder.Services.AddSingleton<IMessageController, MessageController>();
            builder.Services.AddTransient<IMesssageThermoProcessor, PersonelThermoMessageProcessor>();

            builder.Services.AddDbContext<ThermoDataContext>(opt => opt.UseSqlServer(config.GetConnectionString("ThermoDatabase")));
        }
    }
}
