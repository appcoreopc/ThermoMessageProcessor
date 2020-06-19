using AzCloudApp.MessageProcessor.Core.Thermo.DataStore;
using System.Threading.Tasks;
using AzCloudApp.MessageProcessor.Core.Utils;
using Newtonsoft.Json;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class DataStoreMessageProcessor : IDataStoreProcesor
    {
        private readonly ThermoDataContext _thermoDataContext;
        
        public DataStoreMessageProcessor(ThermoDataContext thermoDataContext)
        {
            _thermoDataContext = thermoDataContext;
        }

        public Task<int> SavePersonAsync(string source)
        {
            var target = JsonConvert.DeserializeObject<PersonImgDataMessageQueue>(source);
            this._thermoDataContext.PersonImgs.Add(target.ToModel());
            return this._thermoDataContext.SaveChangesAsync();
        }

        public Task<int> SaveDevicesAsync(string source)
        {
            var target = JsonConvert.DeserializeObject<DeviceDataMessageQueue>(source);
            this._thermoDataContext.Devices.Add(target.ToModel());
            return this._thermoDataContext.SaveChangesAsync();
        }

        public Task<int> SaveAttendRecordAsync(string source)
        {
            var target = JsonConvert.DeserializeObject<AttendRecordDataMessageQueue>(source);
            this._thermoDataContext.AttendRecords.Add(target.ToModel());
            return this._thermoDataContext.SaveChangesAsync();
        }

        public Task<int> SavePersonImgAsync(string source)
        {
            var target = JsonConvert.DeserializeObject<PersonImgDataMessageQueue>(source);
            this._thermoDataContext.PersonImgs.Add(target.ToModel());
            return _thermoDataContext.SaveChangesAsync();
        }
    }
}
