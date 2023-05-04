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
    }
}