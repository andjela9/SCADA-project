using DataConcentrator.Tagovi;
using PLCSimulator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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

    public class Handler
    {
        public Context context { get; set; }
        public PLCSimulatorManager PLC { get; set; }        //pitanje

        public Dictionary<AI, Thread> AIThreads;
        public Dictionary<AO, Thread> AOThreads;
        public Dictionary<DI, Thread> DIThreads;
        public Dictionary<DO, Thread> DOThreads;

    }
}
