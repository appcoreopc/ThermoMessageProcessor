using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using System.Threading.Tasks;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public interface IDataStoreProcesor
    {
        Task<int> ProcessAsync(PersonelThermoDataModel source);

        Task<int> SavePersonAsync(PersonImgDataMessageQueue source);

        Task<int> SaveDevicesAsync(DeviceDataMessageQueue source);

        Task<int> SaveAttendRecordAsync(AttendRecordDataMessageQueue source);

        Task<int> SavePersonAsync(PersonDataMessageQueue source);
    }
}
