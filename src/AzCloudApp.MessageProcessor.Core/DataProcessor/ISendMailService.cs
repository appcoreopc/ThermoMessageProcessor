using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public interface ISendMailService
    {
        Task<int> SendMailAsync(AttendRecord record); 
    }

    public class SendMailService : ISendMailService
    {
        public Task<int> SendMailAsync(AttendRecord record)
        {
            return Task.FromResult(1);
        }
    }
}