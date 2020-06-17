﻿using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ThemoDataMessageProcessor.DataProcessor;
using ThemoDataMessageProcessor.PersonelThemoDataHandler;

[assembly: FunctionsStartup(typeof(ThermoDataMessageSender.Startup))]

namespace ThermoDataMessageSender
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddSingleton<IMessageController, MessageController>();
            builder.Services.AddTransient<IMesssageThermoProcessor, PersonelThermoMessageProcessor>();
            
            //builder.Services.AddDbContext<ThermoDataContext>(opt => opt.UseSqlServer(Configuration.("SchoolContext")));
        }
    }
}