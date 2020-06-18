using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public interface INotificationProcessor
    {
        Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source);
    }
}
