﻿using Microsoft.Azure.Functions.Extensions.DependencyInjection;
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
            
            builder.Services.AddDbContext<ThermoDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("")));
        }
    }
}
