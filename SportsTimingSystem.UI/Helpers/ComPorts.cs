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

            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_SerialPort");
            ManagementObjectCollection collection = searcher.Get();

            for (int i = 0; i < ports.Count; i++)
            {
                foreach (var obj in collection)
                {
                    ports[i] = $"{ports[i]} {obj["Caption"]}";
                }
            }

            return ports;
        }
    }
}