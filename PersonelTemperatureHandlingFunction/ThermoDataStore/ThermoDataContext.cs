using Microsoft.EntityFrameworkCore;
using ThemoDataModel;

namespace ThermoDataStore
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
