using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Wpf.Base;
using Training.Wpf.Commun;

namespace Training.Wpf.UserControls
{
    public abstract class NavigationViewModel : ViewModelBase
    {
        protected NavigationViewModel(IContext context)
        {
            _context=  context;
        }
        public abstract string Name { get; }
        protected IContext _context;
    }
}
