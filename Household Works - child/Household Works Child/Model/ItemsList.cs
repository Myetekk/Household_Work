using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works_Child.Model
{
    public class ItemsList
    {
        private string kid_name;
        public string Kid_Name
        {
            get => kid_name;
            set
            {
                kid_name = value;
            }
        }

        public override string ToString()
        {
            return String.Format(Kid_Name); 
        }

        public virtual event PropertyChangedEventHandler PropertyChanged;
        public virtual void NotifyPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames) 
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                PropertyChanged(this, new PropertyChangedEventArgs("HasError"));
            }
        }
    }
}
