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
using A_Mapping2.Models;

namespace A_Mapping2.Views.Pages
{
    /// <summary>
    /// Interaction logic for MindMapPage.xaml
    /// </summary>
    public partial class MindMapPage : Page
    {
        public MindMapPage(MapaMental mapa)
        {
            InitializeComponent();
            MapTitle.Text = mapa.Titulo;

            // Carrega imagem do projeto
            var image = new BitmapImage(new System.Uri(mapa.ImagemPath, System.UriKind.Relative));
            MapImage.Source = image;
        }
    }
}
