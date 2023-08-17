using Ganss.Excel;
using SportsTimingSystem.UI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsTimingSystem.UI.Helpers
{
    public static class ExcelManager
    {
        public static List<RunnerData> Map(string filePath)
        {
            var data = new ExcelMapper(filePath)
                .Fetch<RunnerData>(0).ToList();
            return data;
        }

        public static void Save(string filePath, List<RunnerData> data)
        {
            var mapper = new ExcelMapper();
            mapper.Save(filePath, data, 0);
        }
    }
}
