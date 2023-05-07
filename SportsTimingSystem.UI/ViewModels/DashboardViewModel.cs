using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using SportsTimingSystem.UI.Helpers;
using SportsTimingSystem.UI.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;

namespace SportsTimingSystem.UI.ViewModels
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private ObservableCollection<RunnerData> _results;

        [ObservableProperty]
        private ObservableCollection<string> _usbPorts;

        [ObservableProperty]
        private string _selectedUsbPort;

        [ObservableProperty]
        private bool _isConnected;

        [ObservableProperty]
        private bool _isArduinoSelected;

        [ObservableProperty]
        private bool _isFileImported;

        [ObservableProperty]
        private string _filePath;

        [ObservableProperty]
        private RunnerData _tempRunner;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom()
        {
            // Method intentionally left empty.
        }

        private void InitializeViewModel()
        {
            UsbPorts = new ObservableCollection<string>(ComPorts.GetComPorts());
            TempRunner = new RunnerData();

            IsConnected = false;
            _isInitialized = true;
        }

        partial void OnSelectedUsbPortChanged(string value)
        {
            IsArduinoSelected = SelectedUsbPort.Contains("Arduino");
        }

        partial void OnFilePathChanged(string value)
        {
            Results = new ObservableCollection<RunnerData>(ExcelManager.Map(FilePath));
        }

        partial void OnResultsChanged(ObservableCollection<RunnerData> value)
        {
            IsFileImported = true;
        }

        [RelayCommand]
        private Task Start()
        {
            IsConnected = ComPorts.TestConnection(SelectedUsbPort.Substring(0, 4));
            return Task.CompletedTask;
        }

        [RelayCommand]
        private Task SaveNewParticipantData()
        {
            if (Results is not null)
            {
                Results.Add(TempRunner);
            }
            else
            {
                Results = new ObservableCollection<RunnerData> { TempRunner };
            }

            TempRunner = new RunnerData();

            return Task.CompletedTask;
        }

        [RelayCommand]
        private Task ImportDataFromExcelFile()
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() is true)
            {
                FilePath = openFileDialog.FileName;
            }

            return Task.CompletedTask;
        }

        [RelayCommand]
        private Task ExportDataToExcelFile()
        {
            if (FilePath is not null)
            {
                var directoryPath = Path.GetDirectoryName(FilePath);
                ExcelManager.Save(directoryPath + "/exportedData.xlsx", Results.ToList());
            }

            return Task.CompletedTask;
        }

    }
}