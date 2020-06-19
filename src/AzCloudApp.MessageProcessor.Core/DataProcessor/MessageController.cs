using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class MessageController : IMessageController
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IDataStoreProcesor _dataStoreProcesor;
        private readonly INotificationProcessor _notificationProcesor;

        public MessageController(ILogger<MessageController> logger,
            IDataStoreProcesor dataStoreProcesor, INotificationProcessor notificationProcesor)
        {
            _logger = logger;
            _dataStoreProcesor = dataStoreProcesor;
            _notificationProcesor = notificationProcesor;
        }

        // Peek message type //
        public Task ProcessDataAsync(string sourceData)
        {
            this._logger.LogInformation($"MessageController::ProcessDataAsync executes : {DateTime.Now}");

            try
            {
                var messsageType = GetMessageType(sourceData);

                switch (messsageType.MessageType)
                {
                    case 0:
                        this._logger.LogInformation("Person processing record.");
                        _dataStoreProcesor.SavePersonAsync(sourceData);
                        break;
                    case 1:
                        this._logger.LogInformation("Image processing record");
                        _dataStoreProcesor.SavePersonImgAsync(sourceData);
                        break;
                    case 2:
                        this._logger.LogInformation("Device processing record ");
                        _dataStoreProcesor.SaveDevicesAsync(sourceData);
                        break;
                    case 3:
                        this._logger.LogInformation("Attendance processing record");
                        _dataStoreProcesor.SaveAttendRecordAsync(sourceData);
                        _notificationProcesor.ProcessAsync(sourceData);
                        break;
                    default:
                        break;
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

        private ThermoBaseMessageType GetMessageType(string sourceData)
        {
            return JsonConvert.DeserializeObject<ThermoBaseMessageType>(sourceData);
        }
    }
}
