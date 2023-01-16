using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_test
{
    public class RunnerResults : RunnerData
    {
        private int _id;
        private string _country;
        private double _result;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public double Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public RunnerResults(string firstname, string lastname, int runnerNumber, string country, double result, int id) : base(firstname, lastname, runnerNumber)
        {
            _id = id;
            _country = country;
            _result = result;
        }
    }
}
