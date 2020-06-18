using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class DataStoreMessageProcessor : IDataStoreProcesor
    {   
        public DataStoreMessageProcessor()
        {
        }

        public Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source)
        {
            
            return Task.FromResult(new ExecutionState());
        }
    }

    public class NotificationMessageProcessor : INotificationProcessor
    {
        public NotificationMessageProcessor()
        {
        }

        public Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source)
        {
            return Task.FromResult(new ExecutionState());
        }
    }
}
