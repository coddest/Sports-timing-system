using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTimingSystem.UI.Models
{
    public class RunnerResults : RunnerData
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public double Result { get; set; }
    }
}
