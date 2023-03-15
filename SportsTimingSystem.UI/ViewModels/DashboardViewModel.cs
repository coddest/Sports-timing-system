using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportsTimingSystem.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Wpf.Ui.Common.Interfaces;

namespace SportsTimingSystem.UI.ViewModels
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private ObservableCollection<RunnerResults> _results;

        [ObservableProperty]
        private ObservableCollection<string> _usbPorts;

        [ObservableProperty]
        private string _timer = string.Empty;
        
        private DispatcherTimer _dispatcherTimer;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom()
        {
        }

        private void InitializeViewModel()
        {
            Results = new ObservableCollection<RunnerResults> { new RunnerResults { FirstName = "Andrzej", LastName = "Ptak", Country = "Poland", Id = 1, Result = 22, RunnerNumber = 22 } };
            UsbPorts = new ObservableCollection<string> { "usb1", "usb2" };

        _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Tick += Timer_Tick;

            _isInitialized = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer = DateTime.Now.ToString("HH:mm:ss");
        }


        [RelayCommand]
        private Task Start()
        {
            _dispatcherTimer.Start();
            return Task.CompletedTask;
        }
    }
}
