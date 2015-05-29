using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UI.WinForms
{
    public interface IWinformViewModel<Model>
    {
        Model ViewModel { get; set; }
    }
}
