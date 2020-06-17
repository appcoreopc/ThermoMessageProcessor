using System.Threading.Tasks;
using ThemoDataModel;

namespace ThemoDataMessageProcessor.DataProcessor
{
    class DataStoreMessageProcessor : IDataProcesor
    {

        public DataStoreMessageProcessor()
        {

        }

        public Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source)
        {
            return Task.FromResult(new ExecutionState());
        }
    }

    class NotificationMessageProcessor : IDataProcesor
    {
        public Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source)
        {
            return Task.FromResult(new ExecutionState());
        }
    }
}
