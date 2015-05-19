using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class TestEvent : PubSubEvent<String>
    {
        public String Name { get; set; }
    }
}
