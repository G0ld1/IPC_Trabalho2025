using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using A_Mapping2.Helpers;
using A_Mapping2.Models;

namespace A_Mapping2.ViewModels
{
    class HomeViewModel : BaseViewModel
    {

        public string Username { get; }
        public ObservableCollection<MapaMental> MindMaps { get; } = new();

        public ICommand CreateMindMapCommand { get; }

        public HomeViewModel(string username)
        {
            Username = username;
            MindMaps.Add(new MapaMental { Titulo = "Mapa: Estudos", ImagemPath = "/Assets/mapa1.png" });
            MindMaps.Add(new MapaMental { Titulo = "Mapa: Projeto X", ImagemPath = "/Assets/mapa2.png" });
            MindMaps.Add(new MapaMental { Titulo = "Mapa: Ideias", ImagemPath = "/Assets/mapa3.png" });

            CreateMindMapCommand = new RelayCommand(_ => AddNewMindMap()); 
        }

        public void AddNewMindMap(MapaMental novoMapa = null)
        {
            if (novoMapa != null)
            {
                MindMaps.Add(novoMapa);
                return;
            }

            var newMapa = new MapaMental
            {
                Titulo = $"Mapa {MindMaps.Count + 1}",
                ImagemPath = "/Assets/mapa_default.png"
            };
            MindMaps.Add(newMapa);
        }
    }
}
