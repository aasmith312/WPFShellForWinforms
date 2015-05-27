using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformToBeHosted2.Views;
using System.Runtime;
using System.Windows.Forms;
using Common.UI.WPF;

namespace WinformToBeHosted2
{
    public class WinformToBeHosted2Module : IModule
    {
        IUnityContainer iContainer;

        public WinformToBeHosted2Module(IUnityContainer iCon) 
        {
            this.iContainer = iCon;
        }
        
        public void Initialize()
        {
            iContainer.RegisterType<IWinformToBeHostedModel, WinformToBeHostedModel>();
            iContainer.RegisterType<IWinformToBeHosted, WinformToBeHosted>();

            IWinformToBeHosted tmp = iContainer.Resolve<IWinformToBeHosted>();

            iContainer.Resolve<IEventAggregator>().GetEvent<WinformToBeAddedEvent>().Publish(
                new WinformToBeAddedEventPayload() { Form = tmp as Form, ToValidate = typeof(WinformToBeHosted) });
        }
    }
}
