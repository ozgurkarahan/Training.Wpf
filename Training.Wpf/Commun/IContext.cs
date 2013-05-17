using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Training.Wpf.UserControls;
namespace Training.Wpf.Commun
{
    public interface IContext
    {
        ObservableCollection<PersonModel> Persons { get; set; }
    }
}
