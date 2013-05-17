using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Wpf.Base
{
    public interface IViewModelBase
    {
        string DisplayName { get; }
        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
