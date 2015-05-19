using Events;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformToBeHosted2.Views
{
    public class WinformToBeHostedModel : IWinformToBeHostedModel
    {
        IUnityContainer container;

        public WinformToBeHostedModel(IUnityContainer container, IWinformToBeHosted WinformToBeHosted)
        {
            container.Resolve<IEventAggregator>().GetEvent<TestEvent>().Publish("Hello");

            WinformToBeHosted.Model = this;
            this.container = container;
        }


    }
}
