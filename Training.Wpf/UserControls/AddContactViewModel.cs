using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Training.Wpf.Base;
using Training.Wpf.Commun;

namespace Training.Wpf.UserControls
{
    public class AddContactViewModel : NavigationViewModel
    {
        public AddContactViewModel(IContext context)
            : base(context)
        {
            TempContact = new PersonModel();
            AddCommand = new RelayCommand(p => AddPerson(), p => CanAddPerson());
        }

        private bool CanAddPerson()
        {
            return TempContact != null && TempContact.IsValid();
        }

        private void AddPerson()
        {
            this._context.Persons.Add(TempContact);
            TempContact = new PersonModel();
        }

        private PersonModel _tempContact;
        public PersonModel TempContact
        { get { return _tempContact; }
            set 
            {
                _tempContact = value;
                OnPropertyChanged("TempContact");
            }
        }
        public ICommand AddCommand { get; set; }


        public override string Name
        {
            get { return Properties.Resources.EcranNameAddContact; }
        }
    }
}
