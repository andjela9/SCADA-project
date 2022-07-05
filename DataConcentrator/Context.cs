using DataConcentrator.Tagovi;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Context : DbContext
    {
        public DbSet<AI> AnalogInputs { get; set; }
        public DbSet<AO> AnalogOutputs { get; set; }
        public DbSet<DI> DigitalInputs { get; set; }
        public DbSet<DO> DigitalOutputs { get; set; }
        public DbSet<Alarm> Alarms { get; set; }


    }
}
