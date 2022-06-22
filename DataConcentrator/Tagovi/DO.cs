using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Tagovi
{
    public class DO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string tagName;
        private string description;
        private string address;
        private double initialValue;
        private double currentValue;

        public DO(string tagName, string description, string address, double initialValue, double currentValue)
        {
            this.tagName = tagName;
            this.description = description;
            this.address = address;
            this.initialValue = initialValue;
            this.currentValue = currentValue;
        }

        public DO() { }

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

        public double InitialValue
        {
            get { return initialValue; }
            set
            {
                initialValue = value;
                OnPropertyChanged("InitialValue");
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
