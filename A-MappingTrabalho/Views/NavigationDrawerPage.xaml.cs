using System;
using System.Windows.Controls;
using A_MappingTrabalho.ViewModels;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Tools.Controls;
namespace A_MappingTrabalho.Views
{
    public partial class NavigationDrawerPage : Page
    {
		public string themeName = App.Current.Properties["Theme"]?.ToString()!= null? App.Current.Properties["Theme"]?.ToString(): "Windows11Light";
        public NavigationDrawerPage(NavigationDrawerViewModel viewModel)
        {
            InitializeComponent();		
            DataContext = viewModel;
			SfSkinManager.SetTheme(this, new Theme(themeName));
        }	
    }
}
