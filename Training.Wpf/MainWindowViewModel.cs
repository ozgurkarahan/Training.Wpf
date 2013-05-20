using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Wpf.Base;
using Training.Wpf.UserControls;
using System.Collections.ObjectModel;
using Training.Wpf.Commun;
using System.Windows.Input;
using Training.Wpf.Helper;

namespace Training.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            Initialize();           
        }

        private void Initialize() 
        {
            InitializeNavigationViewModels();
            EcranPreviousCommand = new RelayCommand(p => EcranPrevious(), p => CanEcranPrevious());
            EcranNextCommand = new RelayCommand(p => EcranNext(), p => CanEcranNext());
        }

        private void InitializeNavigationViewModels()
        {
            foreach (var item in ConfigurationHelper.Container.ResolveAll<NavigationViewModel>())
            {
                Ecrans.Add(item);
            }
        }

        public IContext Context { get; set; }

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
                RaisePropertyChanged("Ecrans");
            }
        }

        private NavigationViewModel _selectedEcran;
        public NavigationViewModel SelectedEcran
        {
            get { return _selectedEcran; }
            set
            {
                _selectedEcran = value;
                RaisePropertyChanged("SelectedEcran");
            }
        }

        


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
