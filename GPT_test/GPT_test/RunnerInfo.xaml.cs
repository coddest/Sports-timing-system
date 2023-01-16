using System;
using System.Collections.Generic;
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
    /// Interaction logic for RunnerInfo.xaml
    /// </summary>
    public partial class RunnerInfo : UserControl
    {
        List<RunnerData> RunnersInfoDataSource { get; set; } = new List<RunnerData> { new RunnerData("John", "Smith", 1), new RunnerData("Jane", "Doe", 2), new RunnerData("Joe", "Bloggs", 3) };

        public RunnerInfo()
        {
            InitializeComponent();
            lvDataBinding.ItemsSource = RunnersInfoDataSource;
        }
    }
}
