using Common.UI;
using Common.UI.WinForms;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformToBeHosted2.Views
{
    public class WinformToBeHostedModel : ViewModelBaseWinForm, IWinformToBeHostedModel
    {
        String label = String.Empty;

        public String Label
        {
            get { return this.label; }
            set 
            {
                this.Set(ref label, value);
            }
        }

        public WinformToBeHostedModel(IUnityContainer container) 
            : base(container)
        {
            this.Label = "Hi From the Model.";
        }
    }
}
