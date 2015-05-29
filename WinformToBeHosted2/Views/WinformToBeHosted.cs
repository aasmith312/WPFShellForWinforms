using Common.UI.WinForms;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformToBeHosted2.Views
{
    public partial class WinformToBeHosted : BaseWinform, IWinformToBeHosted, IWinformViewModel<IWinformToBeHostedModel>
    {
        [Dependency]
        public IWinformToBeHostedModel ViewModel
        {
            get
            {
                return this.bindingSource1.DataSource as IWinformToBeHostedModel;
            }
            set
            {
                this.bindingSource1.DataSource = value;
            }
        }

        public WinformToBeHosted() : base()
        {
            InitializeComponent();
        }


    }
}
