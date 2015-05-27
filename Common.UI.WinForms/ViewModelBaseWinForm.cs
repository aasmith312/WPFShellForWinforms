using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UI.WinForms
{
    public class ViewModelBaseWinForm : ViewModelBase
    {
        public IUnityContainer Container
        {
            get;
            set;
        }

        public ViewModelBaseWinForm(IUnityContainer container) : base()
        {
            this.Container = container;
        }
    }
}
