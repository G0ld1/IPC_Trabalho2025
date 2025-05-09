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

            var user = UserDataStore.CurrentUser;
            if (user != null)
            {
                foreach (var mapa in user.MapasMentais)
                    MindMaps.Add(mapa);
            }

            var view = CollectionViewSource.GetDefaultView(MindMaps);
            view.GroupDescriptions.Add(new PropertyGroupDescription("GrupoCronologico"));
            view.SortDescriptions.Add(new SortDescription("DataCriacao", ListSortDirection.Descending));
            GroupedMindMaps = view;


            CreateMindMapCommand = new RelayCommand(_ => AddNewMindMap());

            //Comandos para editar nome e eliminar

          
        }

      

        public void AddNewMindMap(MapaMental novoMapa = null)
        {
            var mapa = novoMapa ?? new MapaMental
            {
                Titulo = $"Mapa {MindMaps.Count + 1}",
                ImagemPath = "/Assets/mapa_default.png"
            };

            MindMaps.Add(mapa);
            UserDataStore.CurrentUser?.MapasMentais.Add(mapa);
            UserDataStore.SaveCurrentUser(); // método novo que vais criar
        }
    }
}
