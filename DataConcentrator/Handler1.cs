using DataConcentrator.Tagovi;
using PLCSimulator;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;

namespace DataConcentrator
{
    public class Handler            //ovaj fajl ako se zove Handler dobije se greska property or indexer must have at least one accessor
    {
        public Context context { get; set; }
        public PLCSimulatorManager PLC { get; set; }        

        public Dictionary<AI, Thread> AIThreads;
        public Dictionary<AO, Thread> AOThreads;
        public Dictionary<DI, Thread> DIThreads;
        public Dictionary<DO, Thread> DOThreads;

        public Handler()
        {
            if(context == null)
            {
                context = new Context();
            }
            PLC = new PLCSimulatorManager();

            AIThreads = new Dictionary<AI, Thread>();
            AOThreads = new Dictionary<AO, Thread>();
            DIThreads = new Dictionary<DI, Thread>();
            DOThreads = new Dictionary<DO, Thread>();
        }

        public void LoadContext()       //trebace za main u skadi
        {
            context.Alarms.Load();
            context.AnalogInputs.Load();
            context.AnalogOutputs.Load();
            context.DigitalInputs.Load();
            context.DigitalOutputs.Load();
        }

        public void PLCSetValue()
        {
            foreach(var ao in context.AnalogInputs)
            {
                PLC.SetAnalogValue(ao.Address, ao.CurrentValue);
            }
            foreach(var Do in context.DigitalInputs)
            {
                PLC.SetDigitalValue(Do.Address, Do.CurrentValue);
            }
        }

        //AI

        public void GetAIValue(AI ai)
        {
            while (true)
            {
                ai.CurrentValue = PLC.GetAnalogValue(ai.Address);
                //uspavati nit za scan time
                Thread.Sleep(ai.ScanTime * 1000);
            }
        }

        public void StartAI()
        {
            foreach(AI ai in context.AnalogInputs)          //za sve inpute doda nit, doda u recnik, pokrene
            {
                //TODO: trebalo bi zakljucati ili koristiti one recnike gde je to uradjeno
                Thread AIThread = new Thread(() => GetAIValue(ai));
                AIThreads.Add(ai, AIThread);
                AIThread.Start();
            }
        }

        public void StopAI()
        {
            foreach(AI ai in context.AnalogInputs)
            {
                AIThreads[ai].Abort();          //nadje bas taj tred i prekine ga

            }
        }

        public void AddAI(AI ai)           //mozda mi ne bude trebalo 
        {
            Thread AIThread = new Thread(() => GetAIValue(ai));     //za konkretan input napravi nit, doda u recnik, pokrene
            AIThreads.Add(ai, AIThread);
            AIThread.Start();
        }


        //DI
        public void GetDIValue(DI di)           //mogle bi se mozda GetAIValue i GetDIValue parametrizovati tako da budu jedna metoda, tipa neki objekat al tu bi moglo puci na kastu, razmisliti na kraju
        {
            while (true)
            {
                di.CurrentValue = PLC.GetAnalogValue(di.Address);           //ova metoda bi trebalo da getuje i analogne i digitalne
                //uspavati nit za scan time
                Thread.Sleep(di.ScanTime * 1000);
            }
        }

        public void StartDI()
        {
            foreach (DI di in context.DigitalInputs)          //za sve inpute doda nit, doda u recnik, pokrene
            {
                //TODO: trebalo bi zakljucati ili koristiti one recnike gde je to uradjeno
                Thread DIThread = new Thread(() => GetDIValue(di));
                DIThreads.Add(di, DIThread);
                DIThread.Start();
            }
        }

        public void StopDI()
        {
            foreach (DI di in context.DigitalInputs)
            {
                DIThreads[di].Abort();          //nadje bas taj tred i prekine ga
            }
        }

        public void AddDI(DI di)           //mozda mi ne bude trebalo 
        {
            Thread DIThread = new Thread(() => GetDIValue(di));     //za konkretan input napravi nit, doda u recnik, pokrene
            DIThreads.Add(di, DIThread);
            DIThread.Start();
        }
    }
}
