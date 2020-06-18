using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public interface IDataStoreProcesor
    {
        Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source);
    }
}
