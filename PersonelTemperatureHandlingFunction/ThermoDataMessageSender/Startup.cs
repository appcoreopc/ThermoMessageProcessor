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

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddSingleton<IMessageController, MessageController>();
            builder.Services.AddTransient<IMesssageThermoProcessor, PersonelThermoMessageProcessor>();
            builder.Services.AddDbContext<ThermoDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));
        }
    }
}
