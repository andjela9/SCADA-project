using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public enum AlarmBelowOrAbove
    {
        BELOW,
        ABOVE
    }

    

    public class Alarm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //vrednost granice, da li se aktivira na iznad ili ispod, poruka, id, velicina nad kojom se desio, vreme
        private string alarmName;
        private string message;
        private AlarmBelowOrAbove belowOrAbove;
        private double limitValue;
        private int alarmID;
        private DateTime dateTime;

        public Alarm(string alarmName, string message, AlarmBelowOrAbove belowOrAbove, double limitValue, int alarmID, DateTime dateTime)
        {
            this.alarmName = alarmName;
            this.message = message;
            this.belowOrAbove = belowOrAbove;
            this.limitValue = limitValue;
            //this.alarmID = alarmID;       ovo ce prilikom kreiranja kljuca i baze
            //this.dateTime = dateTime;     ne moze ovako, mora trenutno vreme
            dateTime = new DateTime();
        }

        public Alarm() { }


        #region Properties
        public string AlarmName
        {
            get { return alarmName; }
            set
            {
                alarmName = value;
                OnPropertyChanged("AlarmName");
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public AlarmBelowOrAbove BelowOrAbove
        {
            get { return belowOrAbove; }
            set
            {
                belowOrAbove = value;
                OnPropertyChanged("BelowOrAbove");
            }
        }

        public double LimitValue
        {
            get { return limitValue; }
            set
            {
                limitValue = value;
                OnPropertyChanged("LimitValue");
            }
        }

        public int AlarmID
        {
            get { return alarmID; }
            set
            {
                alarmID = value;
                OnPropertyChanged("AlarmID");
            }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");
            }
        }
        #endregion

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public bool AlarmOn(double currValue)
        {
            if (this.belowOrAbove == AlarmBelowOrAbove.BELOW)
            {
                if (this.limitValue > currValue)
                {
                    return true;            //alarm se aktivira ako vrednost padne ispod limita
                }
                else return false;          //ako ne padne nikom nista
            }else if(this.belowOrAbove == AlarmBelowOrAbove.ABOVE)
            {
                if (this.limitValue < currValue)
                {
                    return true;           //alarm se aktivira ako vrednost predje preko limita
                }
                else return false;          //vrednost nije presla preko limita
            }
            else
            {
                return false;               //ne postoji alarm uopste
            }
        }

        //neki ispis, mozda preko xaml a mozda i ovde bude potrebno

    }
}
