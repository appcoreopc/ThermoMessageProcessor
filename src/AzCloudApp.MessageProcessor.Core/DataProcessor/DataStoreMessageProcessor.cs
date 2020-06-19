using AzCloudApp.MessageProcessor.Core.Thermo.DataStore;
using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class DataStoreMessageProcessor : IDataStoreProcesor
    {

        private readonly ThermoDataContext _thermoDataContext;

        public DataStoreMessageProcessor(ThermoDataContext thermoDataContext)
        {
            _thermoDataContext = thermoDataContext;
        }

        public Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source)
        {

            _thermoDataContext.SaveChanges();
            return Task.FromResult(new ExecutionState());
        }
    }
}
