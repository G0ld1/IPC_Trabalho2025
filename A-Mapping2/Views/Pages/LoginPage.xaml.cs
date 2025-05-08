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
using A_Mapping2.ViewModels;

namespace A_Mapping2.Views.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private Frame _navigationFrame;
        public LoginPage(Frame navigationFrame)
        {
            InitializeComponent();
            _navigationFrame = navigationFrame;
            DataContext = new LoginViewModel(navigationFrame);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LoginViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AttemptLogin();
            }
        }
        private void AttemptLogin()
        {
            if (this.DataContext is LoginViewModel vm)
            {
                if (vm.LoginCommand.CanExecute(null))
                {
                    vm.LoginCommand.Execute(null);
                }
            }
        }
        private void LanguageSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is ComboBoxItem selectedItem)
            {
                string languageCode = selectedItem.Tag.ToString();
                ((App)Application.Current).ChangeLanguage(languageCode);
            }
        }
        private void NavigateToRegisterPage(object sender, MouseButtonEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Navigate(new RegisterPage(_navigationFrame));
            }
        }
        private void ShowPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e) { 
            if(PasswordUnmask.Visibility == Visibility.Visible) {
                HidePasswordFunction();
            }
            else { 
                ShowPasswordFunction();
            }
        }
        
        private void ShowPasswordFunction()
        {
            ShowPassword.Text = "👁";
            PasswordUnmask.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Hidden;
            PasswordUnmask.Text = PasswordBox.Password;
        }

        private void HidePasswordFunction()
        {
            ShowPassword.Text = "👁";
            PasswordUnmask.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Visible;
        }
    }
}
