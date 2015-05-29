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
    public class ViewModelBase : INotifyPropertyChanged
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
        // Notice that the validation check is not present.
        // There isn't a need with the use of the CallerMemberName param attribute.
        protected void Set<T>(ref T toBeSet, T value, [CallerMemberName]String propName = "")
        {
            toBeSet = (T)value;
            NotifyPropertyChanged(propName);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
