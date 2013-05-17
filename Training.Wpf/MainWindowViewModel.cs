using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Wpf.Base;
using Training.Wpf.UserControls;
using System.Collections.ObjectModel;
using Training.Wpf.Commun;
using System.Windows.Input;

namespace Training.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            this.Context = new Context();
            var tmpCar = new CarnetAdresseViewModel(this.Context);
            Ecrans.Add(tmpCar);
            var tmpGrid = new GridAddressViewModel(this.Context);
            Ecrans.Add(tmpGrid);
            EcranPreviousCommand = new RelayCommand(p => EcranPrevious(), p => CanEcranPrevious());
            EcranNextCommand = new RelayCommand(p => EcranNext(), p => CanEcranNext());
        }

        private ObservableCollection<NavigationViewModel> _ecrans;
        public ObservableCollection<NavigationViewModel> Ecrans
        {
            get
            {
                if (_ecrans == null)
                {
                    _ecrans = new ObservableCollection<NavigationViewModel>();
                }
                return _ecrans;
            }
            set
            {
                _ecrans = value;
                OnPropertyChanged("Ecrans");
            }
        }

        private NavigationViewModel _selectedEcran;
        public NavigationViewModel SelectedEcran
        {
            get { return _selectedEcran; }
            set
            {
                _selectedEcran = value;
                OnPropertyChanged("SelectedEcran");
            }
        }

        public IContext Context { get; set; }

        public CarnetAdresseViewModel CarnetAdresse { get; set; }


        private bool CanEcranPrevious()
        {
            if (SelectedEcran == null)
                return false;
            var currentIndex = this.Ecrans.IndexOf(SelectedEcran);
            return currentIndex == 0 ? false : true;
        }

        public ICommand EcranPreviousCommand
        { get; set; }

        private void EcranPrevious()
        {
            var currentIndex = this.Ecrans.IndexOf(SelectedEcran);
            SelectedEcran = Ecrans[currentIndex - 1];
        }

        private bool CanEcranNext()
        {
            if (SelectedEcran == null)
                return false;
            var currentIndex = this.Ecrans.IndexOf(SelectedEcran);
            return this.Ecrans.Count - 1 == currentIndex ? false : true;
        }

        public ICommand EcranNextCommand
        { get; set; }

        private void EcranNext()
        {
            var currentIndex = this.Ecrans.IndexOf(SelectedEcran);
            SelectedEcran = Ecrans[currentIndex + 1];
        }

    }
}
