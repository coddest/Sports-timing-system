using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPT_test
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort;

        public MainWindow()
        {
            InitializeComponent();

            // Populate the combo box with a list of available serial ports
            cmbSerialPorts.ItemsSource = SerialPort.GetPortNames();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected serial port from the combo box
            string serialPortName = cmbSerialPorts.SelectedItem as string;

            // Open a connection to the serial port
            serialPort = new SerialPort(serialPortName, 9600);
            serialPort.Open();

            // Send a message to the Arduino
            serialPort.WriteLine("Hello, Arduino!");

            // Read the response from the Arduino
            string response = serialPort.ReadLine();

            // Display the response in the text box
            txtResponse.Text = response;
        }
    }
}
