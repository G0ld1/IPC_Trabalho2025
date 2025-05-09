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
        private readonly Frame _navigationFrame;
        public RegisterPage(Frame navigationFrame)
        {
            InitializeComponent();
            _navigationFrame = navigationFrame;
            DataContext = new RegisterViewModel(navigationFrame);
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // TODO: Add logic to handle registration (e.g., save to database, call API, etc.)
            MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            if (this.NavigationService != null)
            {
                this.NavigationService.Navigate(new LoginPage(_navigationFrame));
            }
        }
        private void NavigateToLoginPage(object sender, MouseButtonEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Navigate(new LoginPage(_navigationFrame));
            }
        }
        private void ShowPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PasswordUnmask.Visibility == Visibility.Visible)
            {
                HidePasswordFunction();
            }
            else
            {
                ShowPasswordFunction();
            }
        }

        private void ShowPasswordFunction()
        {
            ShowPassword.Text = "👁";
            PasswordUnmask.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Collapsed;
            PasswordUnmask.Text = PasswordBox.Password;
        }

        private void HidePasswordFunction()
        {
            ShowPassword.Text = "👁";
            PasswordUnmask.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Visible;
        }
    }
}
