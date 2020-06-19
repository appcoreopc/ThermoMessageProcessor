using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public interface ISendMailService
    {
        Task<int> SendMailAsync(AttendRecord record); 
    }
}