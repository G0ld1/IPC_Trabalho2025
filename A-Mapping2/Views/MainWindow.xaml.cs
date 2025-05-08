using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using A_Mapping2.Views.Pages;

namespace A_Mapping2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new RegisterPage(MainFrame));
        MainFrame.Navigated += MainFrame_Navigated;
    }

    private void MainFrame_Navigated(object sender, NavigationEventArgs e)
    {
        var currentPage = MainFrame.Content;

        if (currentPage is Views.Pages.LoginPage || currentPage is Views.Pages.RegisterPage)
        {
            MainFrame.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/Images/Register_Page.png")));
        }
        else
        {
            MainFrame.Background = new SolidColorBrush(Color.FromRgb(28, 13, 22)); 
        }
    }

}