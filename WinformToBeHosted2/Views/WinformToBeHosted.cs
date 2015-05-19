using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityExtensions;

namespace WinformToBeHosted2.Views
{
    public partial class WinformToBeHosted : Form, IWinformToBeHosted
    {
        public WinformToBeHosted()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        //[ServiceDependencyAttribute]
        public IWinformToBeHostedModel Model
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
    }
}
