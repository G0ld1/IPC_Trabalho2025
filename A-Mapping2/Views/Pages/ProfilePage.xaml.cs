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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private readonly Frame _navigationFrame;
        private string _username;

        public ProfilePage(Frame navigationFrame, string username)
        {
            InitializeComponent();
            _navigationFrame = navigationFrame;
            _username = username;

            //UsernameTextBox.Text = _username;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //_username = UsernameTextBox.Text;

            MessageBox.Show($"Nome atualizado para: {_username}");

            // Aqui podias atualizar também o ViewModel principal se estivesse centralizado.
            _navigationFrame.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _navigationFrame.GoBack();
        }
    }
}
