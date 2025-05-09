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
using System.Windows.Navigation;
using System.Windows.Shapes;
using A_Mapping2.Helpers;
using A_Mapping2.ViewModels;
using System.IO;



namespace A_Mapping2.Views.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private readonly Frame _navigationFrame;
        private readonly ProfileViewModel _viewModel;

        public ProfilePage(Frame navigationFrame)
        {
            InitializeComponent();
            _navigationFrame = navigationFrame;

            _viewModel = new ProfileViewModel();

            // Carrega o utilizador atual
            UserDataStore.LoadUser();

            string path = UserDataStore.CurrentUser?.ProfilePicturePath;

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                ProfileEllipse.Fill = new ImageBrush(new BitmapImage(new Uri(path)))
                {
                    Stretch = Stretch.UniformToFill
                };
            }
            else
            {
                ProfileEllipse.Fill = new SolidColorBrush(Colors.Gray); // Fallback
            }

            if (UserDataStore.CurrentUser != null)
            {
                UsernameTextBlock.Text = UserDataStore.CurrentUser.Username;
                EmailTextBlock.Text = UserDataStore.CurrentUser.Email;
            }
            else
            {
                MessageBox.Show("Erro ao carregar dados do utilizador.");
            }
        }

        private void ProfileImage_Click(object sender, MouseButtonEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Imagens (*.png;*.jpg)|*.png;*.jpg"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Atualizar imagem no UI
                ProfileEllipse.Fill = new ImageBrush(new BitmapImage(new Uri(selectedImagePath))) { Stretch = Stretch.UniformToFill };

                // Guardar no user
                var user = UserDataStore.CurrentUser;
                user.ProfilePicturePath = selectedImagePath;

                UserDataStore.SaveCurrentUser(); // Salva no JSON
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            UserDataStore.Logout(); // limpa CurrentUser e as settings

            // Redireciona para a página de login
            _navigationFrame.Navigate(new LoginPage(_navigationFrame));
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PasswordPopup();
            popup.Owner = Application.Current.MainWindow;
            if (popup.ShowDialog() == true)
            {
                // A PasswordPopup deve guardar a nova password no UserDataStore
                MessageBox.Show("Palavra-passe alterada com sucesso!");
            }
        }
    }
}
