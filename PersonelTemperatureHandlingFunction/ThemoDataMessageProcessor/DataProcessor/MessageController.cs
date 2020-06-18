using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ThemoDataModel;

namespace ThemoDataMessageProcessor.DataProcessor
{
    public class MessageController : IMessageController
    {
        private const string SavingMessageToDataStoreMessage = "Saving into database";
        private readonly ILogger<MessageController> _logger;
        private readonly IDataStoreProcesor _dataStoreProcesor;
        private readonly INotificationProcesor _notificationProcesor;
       
        public MessageController(ILogger<MessageController> logger, 
            IDataStoreProcesor dataStoreProcesor, INotificationProcesor notificationProcesor)
        {
            _logger = logger;
            _dataStoreProcesor = dataStoreProcesor;
            _notificationProcesor = notificationProcesor;
        }

        public Task ProcessDataAsync(PersonelThermoDataModel sourceData)
        {
            this._logger.LogInformation($"MessageController source : {DateTime.Now}");

            try
            {
                // Save to database 

                if (sourceData != null)
                {
                    this._logger.LogInformation(SavingMessageToDataStoreMessage);
                    _dataStoreProcesor.ProcessAsync(sourceData);
                }


                if (!string.IsNullOrWhiteSpace(sourceData?.Name))
                {
                    _notificationProcesor.ProcessAsync(sourceData);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error in MessageConroller : {ex.Message}");
                this._logger.LogError($"StackTrace: {ex.StackTrace}");
                throw;
            }

            return Task.CompletedTask;
        }
    }
}
