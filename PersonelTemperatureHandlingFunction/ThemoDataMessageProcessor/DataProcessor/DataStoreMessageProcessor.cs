using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ThemoDataModel;

namespace ThemoDataMessageProcessor.DataProcessor
{
    public class DataStoreMessageProcessor : IDataStoreProcesor
    {
        //private Logger<DataStoreMessageProcessor> _logger;
        public DataStoreMessageProcessor()
        {
            //_logger = logger;
        }

        public Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source)
        {
            
            return Task.FromResult(new ExecutionState());
        }
    }

    public class NotificationMessageProcessor : INotificationProcesor
    {
        //private Logger<NotificationMessageProcessor> _logger;

        public NotificationMessageProcessor()
        {
            //_logger = logger;
        }

        public Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source)
        {
            return Task.FromResult(new ExecutionState());
        }
    }
}
