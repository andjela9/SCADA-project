using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Tagovi
{
    public class DI : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string tagName;
        private string description;
        private string address;
        private int scanTime;
        private double currentValue;

        public DI(string tagName, string description, string address, int scanTime, double currentValue)
        {
            this.tagName = tagName;
            this.description = description;
            this.address = address;
            this.scanTime = scanTime;
            this.currentValue = currentValue;
        }

        public DI() { }

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
        #endregion

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


    }
}
