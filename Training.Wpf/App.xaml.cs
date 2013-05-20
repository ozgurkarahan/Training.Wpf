using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Training.Wpf.UserControls;
using Training.Wpf.Helper;

namespace Training.Wpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            this.MainWindow =  ConfigurationHelper.Container.Resolve<MainWindow>();
            this.MainWindow.DataContext = ConfigurationHelper.Container.Resolve<MainWindowViewModel>();
            this.MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ConfigurationHelper.DisposeContainer();
            base.OnExit(e);
        }
    }
}
