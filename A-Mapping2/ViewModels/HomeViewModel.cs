using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using A_Mapping2.Helpers;
using A_Mapping2.Models;
using System.ComponentModel;
using System.Windows.Data;

namespace A_Mapping2.ViewModels
{
    class HomeViewModel : BaseViewModel
    {

        public string Username { get; }
        public ObservableCollection<MapaMental> MindMaps { get; } = new();
        public ICollectionView GroupedMindMaps { get; }

        public ICommand CreateMindMapCommand { get; }

        public HomeViewModel(string username)
        {
            Username = username;
            MindMaps.Add(new MapaMental { Titulo = "Mapa: Estudos", ImagemPath = "/Assets/mapa1.png", DataCriacao = DateTime.Today });
            MindMaps.Add(new MapaMental { Titulo = "Mapa: Projeto X", ImagemPath = "/Assets/mapa2.png", DataCriacao=DateTime.Today.AddDays(-1) });
            MindMaps.Add(new MapaMental { Titulo = "Mapa: Ideias", ImagemPath = "/Assets/mapa3.png", DataCriacao = DateTime.Today.AddDays(-10) });

            var view = CollectionViewSource.GetDefaultView(MindMaps);
            view.GroupDescriptions.Add(new PropertyGroupDescription("GrupoCronologico"));
            view.SortDescriptions.Add(new SortDescription("DataCriacao", ListSortDirection.Descending));
            GroupedMindMaps = view;


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
