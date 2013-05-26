using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Wpf.Properties;
using System.Collections.ObjectModel;
using Training.Wpf.Commun;

namespace Training.Wpf.UserControls
{
    public class GridAddressViewModel : NavigationViewModel
    {
        public GridAddressViewModel(IContext context) : base(context)
        {
            Persons = _context.Persons;
        }

        public override string Name
        {
            get
            {
                return Resources.EcranNameGridAdresse;
            }
        }

        private ObservableCollection<PersonModel> _persons;
        public ObservableCollection<PersonModel> Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = new ObservableCollection<PersonModel>();
                }
                return _persons;
            }
            set
            {
                _persons = value;
                RaisePropertyChanged("Persons");
            }
        }

    }
}
