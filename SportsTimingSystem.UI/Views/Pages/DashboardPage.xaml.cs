using SportsTimingSystem.UI.ViewModels;
using System.IO;
using System.Windows;
using Wpf.Ui.Common.Interfaces;

namespace SportsTimingSystem.UI.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : INavigableView<ViewModels.DashboardViewModel>
    {
        public ViewModels.DashboardViewModel ViewModel
        {
            get;
        }

        public DashboardPage(ViewModels.DashboardViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }

        private void DropExcel(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".xlsx")
                {
                   ViewModel.FilePath = file;
                }
            }
        }
    }
}