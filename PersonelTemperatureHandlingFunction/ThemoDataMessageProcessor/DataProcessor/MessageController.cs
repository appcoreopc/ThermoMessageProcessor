using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ThemoDataModel;

namespace ThemoDataMessageProcessor.DataProcessor
{
    public class MessageController : IMessageController
    {
        private readonly ILogger _logger;
        private IDataProcesor ds = new DataStoreMessageProcessor();
        private IDataProcesor ns = new NotificationMessageProcessor();

        public MessageController(ILogger logger)
        {
            _logger = logger;
        }

        public Task ProcessDataAsync(PersonelThermoDataModel sourceData)
        {
            this._logger.LogInformation($"MessageController source : {DateTime.Now}");

            // Save to database 

            if (sourceData != null)
            {
                this._logger.LogInformation("Data source is not null, saving into database");
                ds.ProcessAsync(sourceData);
            }

            // Determine if temperature is higher than 37, then write to database /

            if (!string.IsNullOrWhiteSpace(sourceData?.Name))
            {
                this.ns.ProcessAsync(sourceData);
            }

            return Task.CompletedTask;
        }
    }
}
