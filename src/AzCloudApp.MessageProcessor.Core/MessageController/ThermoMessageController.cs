using AzCloudApp.MessageProcessor.Core.DataProcessor;
using AzCloudApp.MessageProcessor.Core.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.MessageController
{
    public class ThermoMessageController : IMessageController
    {
        private readonly ILogger<ThermoMessageController> _logger;
        private readonly IDataStoreProcesor _dataStoreProcesor;
        private readonly INotificationProcessor _notificationProcesor;

        public ThermoMessageController(ILogger<ThermoMessageController> logger,
            IDataStoreProcesor dataStoreProcesor, INotificationProcessor notificationProcesor)
        {
            _logger = logger;
            _dataStoreProcesor = dataStoreProcesor;
            _notificationProcesor = notificationProcesor;
        }

        //var messsageType = GetMessageType(sourceData);
        //_ = messsageType.MessageType switch
        //        {
        //            (0) => _dataStoreProcesor.SavePersonAsync(sourceData),
        //            (1) => _dataStoreProcesor.SavePersonImgAsync(sourceData),
        //            (2) => _dataStoreProcesor.SaveDevicesAsync(sourceData),
        //            (3) => _dataStoreProcesor.SaveAttendRecordAsync(sourceData)
        //};

        public Task ProcessDataAsync(string sourceData)
        {
            this._logger.LogInformation($"MessageController::ProcessDataAsync executes : {DateTime.Now}");

            try
            {
                var messsageType = MessageConverter.GetMessageType<ThermoBaseMessageType>(sourceData);

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
    }
}
