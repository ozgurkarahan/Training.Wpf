using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Training.Wpf.UserControls;

namespace Training.Wpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainwindow = new MainWindow();
            var mainViewModel = new MainWindowViewModel();
            mainwindow.DataContext = mainViewModel;
            this.MainWindow = mainwindow;
            mainwindow.Show();
        }


        
    }
}
