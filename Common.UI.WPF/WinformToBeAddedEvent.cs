using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.UI.WPF
{
    public class WinformToBeAddedEvent : PubSubEvent<WinformToBeAddedEventPayload>
    {
    }
}
