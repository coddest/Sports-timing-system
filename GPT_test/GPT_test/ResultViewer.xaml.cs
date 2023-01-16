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
    /// Interaction logic for ResultViewer.xaml
    /// </summary>
    public partial class ResultViewer : UserControl
    {
        List<RunnerResults> results = new List<RunnerResults> { new RunnerResults("Andrzej", "Ptak", 22, "Polska", 22.22, 5) };

        public ResultViewer()
        {
            InitializeComponent();
            lvDataBinding.ItemsSource = results;
        }
    }
}
