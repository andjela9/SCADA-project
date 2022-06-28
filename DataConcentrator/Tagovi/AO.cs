using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Tagovi
{
    public class AO : INotifyPropertyChanged
    {
        //TODO: oko baze, kljuc, liste, otom potom
        public event PropertyChangedEventHandler PropertyChanged;

        private string tagName;
        private string description;
        private string address;
        private double initialValue;
        private double currentValue;
        private string units;
        //nema liste alarma
        //sigurno nema prikacen alarm

        public AO(string tagName, string description, string address, double currentValue, string unit)
        {
            this.tagName = tagName;
            this.description = description;
            this.address = address;
            this.initialValue = currentValue;
            this.units = unit;
        }

        public AO() { }
        

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
