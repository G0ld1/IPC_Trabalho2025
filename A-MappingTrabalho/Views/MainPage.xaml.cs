using System.Windows.Controls;

using A_MappingTrabalho.ViewModels;

namespace A_MappingTrabalho.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
