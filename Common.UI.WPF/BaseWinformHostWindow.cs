using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Common.UI.WPF
{
    public abstract class BaseWinformHostWindow<T> : Window
    {
        public Grid MainGrid = new Grid();
        public WindowsFormsHost Host = new WindowsFormsHost();

        [Dependency]
        public IUnityContainer Container
        {
            get;
            set;
        }


        public BaseWinformHostWindow()
        {
            WinformToBeAddedEvent t = Container.Resolve<IEventAggregator>().GetEvent<WinformToBeAddedEvent>();
            t.Subscribe(WinformAddedEventHandler, ThreadOption.UIThread, false, Validate);
        }

        public virtual void WinformAddedEventHandler(WinformToBeAddedEventPayload evnt)
        {
            this.Host.Child = evnt.Form as System.Windows.Forms.Control;
            this.MainGrid.Children.Add(this.Host);
            this.AddChild(this.MainGrid);
        }

        public virtual Boolean Validate(WinformToBeAddedEventPayload evt)
        {
            return evt.Form.GetType() == typeof(T);
        }
    }
}
