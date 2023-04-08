using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using NPOI.OpenXmlFormats.Dml;
using SportsTimingSystem.UI.Helpers;
using SportsTimingSystem.UI.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
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
        private string _filePath;

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
            UsbPorts = new ObservableCollection<string>(ComPorts.GetComPorts());


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

        [RelayCommand]
        private Task Start()
        {
            IsConnected = TestConnection(SelectedUsbPort.Substring(0,4));
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

        static bool TestConnection(String SerialPortName)
        {
            try
            {
                SerialPort ArduinoUSB = new SerialPort(SerialPortName);
                
                ArduinoUSB.Open();
                ArduinoUSB.WriteLine("MARCO");
                String answer = ArduinoUSB.ReadLine().Trim();
                ArduinoUSB.Close();

                if (answer == "POLO")
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}