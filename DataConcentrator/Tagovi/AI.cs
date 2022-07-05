using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Tagovi
{
    public enum AlarmState
    {
        None, On, Off
    }

    public class AI : INotifyPropertyChanged
    {
        //TODO: oko baze, kljuc, liste, otom potom

        public event PropertyChangedEventHandler PropertyChanged;

        private string tagName;
        private string description;
        private string address;
        private int scanTime;
        private double currentValue;
        private string units;
        private List<Alarm> alarms;
        private List<Alarm> activeAlarms;

        private AlarmState alarmState;
        //DONE: mozda treba ovde neki field da li ima ili nema prikacen alarm
        //DONE: kad napisem alarme onda i lista alarma

        public AI(string tagName, string description, string address, int scanTime, double currentValue, string unit)
        {
            this.tagName = tagName;
            this.description = description;
            this.address = address;
            this.scanTime = scanTime;
            this.currentValue = currentValue;
            this.units = unit;
            this.currentValue = 0;
            Alarms = new List<Alarm>();
            ActiveAlarms = new List<Alarm>();
            alarmState = AlarmState.None;
        }

        public AI() {
            this.tagName = "";
            this.description = "";
            this.address = "ADDR001";
            this.scanTime = 1;
            this.currentValue = 0;
            this.units = "";
            this.currentValue = 0;
            Alarms = new List<Alarm>();
            ActiveAlarms = new List<Alarm>();
            alarmState = AlarmState.None;

        }



        #region Properties
        //DONE: treba negde da dam kljuc

        private int num;
        [Key]
        public int Num
        {
            get { return num; }
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }
        [NotMapped]         //ovo znaci da ne napravi kolonu za ovo u bazi
        public List<Alarm> Alarms { 
            get { return alarms; }
            set 
            { 
                alarms = value; 
            }
        }
        [NotMapped]
        public List<Alarm> ActiveAlarms { 
            get { return activeAlarms; }
            set
            {
                activeAlarms = value;
            }
        }
        
        


        public string TagName
        {
            get { return tagName; }
            set
            {
                tagName = value;
                OnPropertyChanged("TagName");
            }
        }

        

        public AlarmState AlarmState
        {
            get { return alarmState; }
            set
            {
                alarmState = value;
                OnPropertyChanged("AlarmState");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public int ScanTime
        {
            get { return scanTime; }
            set
            {
                scanTime = value;
                OnPropertyChanged("ScanTime");
            }
        }
        public double CurrentValue
        {
            get { return currentValue; }
            set
            {
                currentValue = value;
                OnPropertyChanged("CurrentValue");
            }
        }
        public string Units
        {
            get { return units; }
            set
            {
                units = value;
                OnPropertyChanged("Units");
            }
        }

        #endregion

       

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
