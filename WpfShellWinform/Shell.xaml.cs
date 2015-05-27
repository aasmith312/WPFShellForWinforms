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
using Common.UI.WPF;
using System.Windows.Forms;

namespace WpfShellWinform
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : BaseWinformHostWindow
    {
        public Shell(IUnityContainer container) : base(container)
        {
            InitializeComponent();
            this.HostedType = typeof(WinformToBeHosted);
        }
    }
}
