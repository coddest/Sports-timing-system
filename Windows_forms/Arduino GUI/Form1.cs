using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino_GUI
{
    public partial class Form1 : Form
    {

        public delegate void d1(string indata);
        double timeResult = 0.0;
        bool run_on = false;

        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = serialPort1.ReadLine();
            if (indata == "run_start")
            {
                run_on = true;
            }
            else if (indata == "run_end")
            {
                run_on = false;
            }
            d1 writeit = new d1(Write2Form);
            Invoke(writeit,indata);
        }

        public void Write2Form(string indata)
        {
            timeResultBox.Text = indata;
        }
    }
}
