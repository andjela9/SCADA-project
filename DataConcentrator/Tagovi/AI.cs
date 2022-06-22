using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Tagovi
{
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
        //mozda treba ovde neki field da li ima ili nema prikacen alarm
        //kad napisem alarme onda i lista alarma

        public AI(string tagName, string description, string address, int scanTime, double currentValue, string unit)
        {
            this.tagName = tagName;
            this.description = description;
            this.address = address;
            this.scanTime = scanTime;
            this.currentValue = currentValue;
            this.units = unit;
        }

        public AI() { }



        #region Properties
        public string TagName
        {
            get { return tagName; }
            set
            {
                tagName = value;
                OnPropertyChanged("TagName");
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
