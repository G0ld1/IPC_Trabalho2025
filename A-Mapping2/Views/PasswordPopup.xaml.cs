using A_Mapping2.Models;
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
using A_Mapping2.Helpers;

namespace A_Mapping2.Views
{
    /// <summary>
    /// Interaction logic for PasswordPopup.xaml
    /// </summary>
    public partial class PasswordPopup : Window
    {
        public PasswordPopup()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            var newPassword = NewPasswordBox.Password;
            var confirmPassword = ConfirmBox.Password;

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword != confirmPassword)
            {
                MessageBox.Show("As palavras-passe não coincidem ou estão vazias.");
                return;
            }

            UserDataStore.UpdatePassword(newPassword);
            this.DialogResult = true; // fecha o popup e indica sucesso
        }
    }
}
