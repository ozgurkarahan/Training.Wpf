using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Training.Wpf.UserControls;

namespace Training.Wpf.Helper
{
    public static class ConfigurationHelper
    {
        private static volatile IWindsorContainer _container;
        private static readonly Object _syncObject = new Object();

        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null) 
                {
                    lock (_syncObject)
                    {
                        if (_container == null) 
                        {
                            _container = new WindsorContainer();
                            RegisterComponents();
                        }   
                    }
                }                    
                return _container;
            }
        }

        private static void RegisterComponents()
        {
            RegisterClassesWithDefaultInterfaces();
            RegisterViewModels();            
        }

        private static void RegisterClassesWithDefaultInterfaces() 
        {
            Container.Register(Classes.FromThisAssembly()
                              .InNamespace("Training.Wpf.Commun", true)
                              .WithServiceDefaultInterfaces()
                              .LifestyleSingleton());

            Container.Register(Classes.FromThisAssembly()
                              .Where(t=>t.Name.EndsWith("Window"))
                              .WithServiceDefaultInterfaces()
                              .LifestyleSingleton());
        }

        private static void RegisterViewModels()
        {
            Container.Register(Component.For<MainWindowViewModel>().Named("MainVM"));            
            Container.Register(Component.For<NavigationViewModel>().Named("AddContactVM").ImplementedBy<AddContactViewModel>());
            Container.Register(Component.For<NavigationViewModel>().Named("CarnetAdresseVM").ImplementedBy<CarnetAdresseViewModel>());
            Container.Register(Component.For<NavigationViewModel>().Named("GridAdresseVM").ImplementedBy<GridAddressViewModel>());
        }

        public static void DisposeContainer() 
        {
            if (_container != null)
            {
                _container.Dispose();
            }
            _container = null;
        }
    }
}
