using AzCloudApp.MessageProcessor.Core.Thermo.DataStore;
using System.Threading.Tasks;
using AzCloudApp.MessageProcessor.Core.Utils;
using AzCloudApp.MessageProcessor.Core.ThermoDataModel;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class DataStoreMessageProcessor : IDataStoreProcesor
    {
        private readonly ThermoDataContext _thermoDataContext;

        public DataStoreMessageProcessor(ThermoDataContext thermoDataContext)
        {
            _thermoDataContext = thermoDataContext;
        }

        public Task<int> SavePersonAsync(PersonImgDataMessageQueue source)
        {
            this._thermoDataContext.PersonImgs.Add(source.ToModel());
            return this._thermoDataContext.SaveChangesAsync();
        }

        public Task<int> SaveDevicesAsync(DeviceDataMessageQueue source)
        {
            this._thermoDataContext.Devices.Add(source.ToModel());
            return this._thermoDataContext.SaveChangesAsync();
        }

        public Task<int> SaveAttendRecordAsync(AttendRecordDataMessageQueue source)
        {
            this._thermoDataContext.AttendRecords.Add(source.ToModel());
            return this._thermoDataContext.SaveChangesAsync();
        }

        public Task<int> SavePersonAsync(PersonDataMessageQueue source)
        {
            this._thermoDataContext.People.Add(source.ToModel());
            return _thermoDataContext.SaveChangesAsync();
        }

        public Task<int> ProcessAsync(PersonelThermoDataModel source)
        {
            return Task.FromResult(1);
        }
    }
}
