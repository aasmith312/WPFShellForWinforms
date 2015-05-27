using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.UI.WPF
{
    public class WinformToBeAddedEventPayload
    {
        public Form Form { get; set; }
        public Type ToValidate { get; set; }
    }
}
