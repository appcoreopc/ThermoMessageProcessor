using System.Threading.Tasks;
using ThemoDataModel;

namespace ThemoDataMessageProcessor.DataProcessor
{
    public interface IMessageController
    {
        Task ProcessDataAsync(PersonelThermoDataModel sourceData);
    }
}