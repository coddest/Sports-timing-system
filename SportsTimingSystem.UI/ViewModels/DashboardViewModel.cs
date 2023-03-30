using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportsTimingSystem.UI.Helpers;
using SportsTimingSystem.UI.Models;
using System;
using System.Collections.ObjectModel;
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
        private ObservableCollection<RunnerResults> _results;

        [ObservableProperty]
        private ObservableCollection<string> _usbPorts;

        [ObservableProperty]
        private bool _isConnected;

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
            UsbPorts = new ObservableCollection<string>(ComPorts.GetComPorts());


            IsConnected = false;
            _isInitialized = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
        }


        [RelayCommand]
        private Task Start()
        {
            var serialPortName = UsbPorts.FirstOrDefault(x => x.Contains("Arduino"))?.Substring(0, 4);
            IsConnected = TestConnection(serialPortName);
            return Task.CompletedTask;
        }

        static bool TestConnection(string serialPortName)
        {
            try
            {
                SerialPort ArduinoUSB = new SerialPort(serialPortName, 9600);
                ArduinoUSB.Open();

                ArduinoUSB.WriteLine("TEST"); // Send the data to the Arduino
                string answer = ArduinoUSB.ReadLine();
                answer = ArduinoUSB.ReadLine();
                ArduinoUSB.Close(); // Close the serial port
                Console.WriteLine(serialPortName + " said: " + answer);

                if (answer.Equals("TEST"))
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

        static void SerialPortMonitor(String SerialPortName, int SerialPortBaudRate)
        {
            SerialPort ArduinoUSB = new SerialPort(SerialPortName, SerialPortBaudRate);
            ArduinoUSB.Open();
            try
            {
                //while (true)
                //{
                String answer = ArduinoUSB.ReadLine();
                answer = ArduinoUSB.ReadLine();
                Console.WriteLine(answer);
                Console.WriteLine(answer.Equals("TEST"));
                Console.WriteLine("TEST");
                if (answer == "TEST")
                {
                    Console.WriteLine("chuj");
                }
                //}
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}