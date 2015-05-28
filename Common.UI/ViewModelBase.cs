using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.UI
{
    public class ViewModelBase :  INotifyPropertyChanged
    {
        // This is a pre 4.5 way of performing this.
        //protected void Set<T>(ref T toBeSet, T value, String strToBeSet)
        //{
        //    if (ViewModelHelper.PropertyExists(this, strToBeSet))
        //    {
        //        toBeSet = (T)value;
        //        NotifyPropertyChanged(strToBeSet);
        //    }
        //}

        // This is 4.5 way of performing this.
        protected void Set<T>(ref T toBeSet, T value, [CallerMemberName]String setterName = "")
        {
            if (ViewModelHelper.PropertyExists(this, setterName))
            {
                toBeSet = (T)value;
                NotifyPropertyChanged(setterName);
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
