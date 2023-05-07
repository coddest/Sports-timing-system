using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;

namespace SportsTimingSystem.UI.Helpers
{
    public static class ComPorts
    {
        public static List<string> GetComPorts()
        {

            List<string> ports = SerialPort.GetPortNames().ToList();

            for (int i = 0; i < ports.Count; i++)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_SerialPort WHERE DeviceID='{ports[i]}'");
                ManagementObjectCollection collection = searcher.Get();

                var sb = new StringBuilder();

                foreach (var obj in collection)
                {
                    sb.Append($"{ports[i]} {obj["Caption"]}");
                }

                ports[i] = sb.ToString();
            }

            return ports;
        }

        public static bool TestConnection(String SerialPortName)
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