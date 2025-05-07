using A_Mapping2.ViewModels;
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

namespace A_Mapping2.Views.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage(Frame navigationFrame)
        {
            InitializeComponent();
            DataContext = new RegisterViewModel(navigationFrame);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RegisterViewModel;
            if (vm?.RegisterCommand.CanExecute(null) == true)
            {
                vm.RegisterCommand.Execute(new[] { PasswordBox, ConfirmPasswordBox });
            }
        }
    }
}
