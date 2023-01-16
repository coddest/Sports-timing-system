using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_test
{
    public class RunnerData
    {
        private string _firstName;
        private string _lastName;
        private int _runnerNumber;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int RunnerNumber
        {
            get { return _runnerNumber; }
            set { _runnerNumber = value; }
        }

        public RunnerData(string firstname, string lastname, int runnerNumber)
        {
            _firstName = firstname;
            _lastName = lastname;
            _runnerNumber = runnerNumber;
        }
    }
}
