using System;
using System.Collections.Generic;
using System.IO;
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
using A_Mapping2.Models;
using A_Mapping2.ViewModels;
using Microsoft.Win32;

namespace A_Mapping2.Views.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page

    {
        private readonly Frame _navigationFrame;
        private string _username;
        private HomeViewModel _viewModel;
        public HomePage(Frame navigationFrame, string username)
        {
            InitializeComponent();
            _username = username;
            _navigationFrame = navigationFrame;
            _viewModel = new HomeViewModel(username);
            DataContext = _viewModel;
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

            this.Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            AtualizarImagemPerfil();
        }



        private void AtualizarImagemPerfil()
        {
            string path = UserDataStore.CurrentUser?.ProfilePicturePath;

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                ProfileEllipse.Fill = new ImageBrush(new BitmapImage(new Uri(path, UriKind.Absolute)))
                {
                    Stretch = Stretch.UniformToFill
                };
            }
            else
            {
                ProfileEllipse.Fill = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _navigationFrame.Navigate(new ProfilePage(_navigationFrame));
        }

        private void MapSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is MapaMental mapa)
            {
                _navigationFrame.Navigate(new MindMapPage(mapa));
            }
        }

        private void DropArea_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void DropArea_Drop(object sender, RoutedEventArgs e)
        {
            var processingWindow = new ProcessingWindow();
            processingWindow.Owner = Window.GetWindow(this); // Define como modal sobre a janela principal
            processingWindow.ProcessingCompleted += (s, args) =>
            {
                processingWindow.Close();

                var novoMapa = new MapaMental
                {
                    Titulo = $"Mapa Importado ({_viewModel.MindMaps.Count + 1})",
                    ImagemPath = "/Assets/mapa_importado.png"
                };

                _viewModel.AddNewMindMap(novoMapa);
            };

            processingWindow.ShowDialog(); // Modal
        }

        private void ButtonFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.*)|*.*", // Adjust the filter as needed
                Title = "Select a File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                DropArea_Drop(sender,e);
            }
        }
    }
}
