using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Training.Wpf.UserControls;

namespace Training.Wpf.Commun
{
    public class Context : IContext
    {
        public Context()
        {
            Persons = new ObservableCollection<PersonModel>();
        }

        public ObservableCollection<PersonModel> Persons
        {
            get;
            set;
        }
    }
}
