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
using System.Windows.Shapes;

namespace A_MappingTrabalho.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();           
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var email = EmailBox.Text;
            var password = PasswordBox.Password;
            var confirm = ConfirmBox.Password;

            if (string.IsNullOrWhiteSpace(username) || password != confirm)
            {
                MessageBox.Show("Erro no registo");
                return;
            }

            // Simula registo e vai para login
            var loginWindow = App.Current is App app ? app.GetService<LoginWindow>() : null;
            loginWindow?.Show();
            this.Close();
        }


    }
}
