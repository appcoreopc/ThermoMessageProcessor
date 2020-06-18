using AzCloudApp.MessageProcessor.Core.ThermoDataModel;
using Microsoft.EntityFrameworkCore;

namespace AzCloudApp.MessageProcessor.Core.Thermo.DataStore
{
    public class ThermoDataContext : DbContext
    {
        public virtual DbSet<PersonImg> PersonImgs { get; set; }
        public virtual DbSet<AttendRecord> AttendRecords { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Person> People { get; set; }

        public ThermoDataContext(DbContextOptions<ThermoDataContext> options) : base(options)
        {

        }
    }
}
