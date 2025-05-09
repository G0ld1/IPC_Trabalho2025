using A_Mapping2.Helpers;
using System.Configuration;
using System.Data;
using System.Windows;

namespace A_Mapping2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        UserDataStore.LoadUser();
        //UserDataStore.AddFakeMindMapsToUser("Filipe");
    }
}

