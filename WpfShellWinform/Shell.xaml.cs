using Events;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinformToBeHosted2.Views;
using System.Runtime;

namespace WpfShellWinform
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public Shell()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TestEvent t = this.Container.Resolve<IEventAggregator>().GetEvent<TestEvent>();
            t.Subscribe(WinformAddedEventHandler, ThreadOption.UIThread, false, GoAhead);
        }


        public void WinformAddedEventHandler(String evnt)
        {
            IWinformToBeHosted Winform = this.Container.Resolve<IWinformToBeHosted>();
            
            WindowsFormsHost host = new WindowsFormsHost();
            host.Child = Winform as System.Windows.Forms.Control;
            
            this.grid1.Children.Add(host);
        }

        public bool GoAhead(String evt)
        {
            return true;
        }
    }
}
