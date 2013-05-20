using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Wpf.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using  Training.Wpf.Properties;
using Training.Wpf.Commun;

namespace Training.Wpf.UserControls
{
    public class CarnetAdresseViewModel : NavigationViewModel
    {
        public CarnetAdresseViewModel(IContext context)
            : base(context)
        {
            AddCommand = new RelayCommand(p => AddPerson(), p => CanAddPerson());
            DelCommand = new RelayCommand(p => DeletePerson(), p => CanDelPerson());

            Persons = _context.Persons;
        }

        public override string Name
        {
            get
            {
                return Resources.EcranNameCarnetAdresse;
            }

        }

        private const int _maxLenght = 10;
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

        private void AddPerson()
        {
            var tmp = new PersonModel();
            this.Persons.Add(tmp);
        }

        private bool CanAddPerson()
        {
            return Persons.Count < _maxLenght;
        }

        private void DeletePerson()
        {
            var lastindex = Persons.Count - 1;
            Persons.RemoveAt(lastindex);
        }

        private bool CanDelPerson()
        {
            return Persons.Count >= 1;
        }

        public ICommand AddCommand { get; set; }

        public ICommand DelCommand { get; set; }

    }
}
