using System.Configuration;
using System.Data;
using System.Windows;

namespace A_Mapping2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    private string _currentLanguage = "en";

    public string CurrentLanguage
    {
        get => _currentLanguage;
        set
        {
            _currentLanguage = value;
            ChangeLanguage(_currentLanguage);
        }
    }

    public void ChangeLanguage(string languageCode)
    {
        var dictionary = new ResourceDictionary();
        switch (languageCode)
        {
            case "en":
                dictionary.Source = new Uri("StringResources.en.xaml", UriKind.Relative);
                break;
            case "pt":
                dictionary.Source = new Uri("StringResources.pt.xaml", UriKind.Relative);
                break;
            default:
                dictionary.Source = new Uri("StringResources.en.xaml", UriKind.Relative);
                break;
        }

        // Update the application's resource dictionaries
        Resources.MergedDictionaries.Clear();
        Resources.MergedDictionaries.Add(dictionary);
        }
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Set English as the default language
        var englishDictionary = new ResourceDictionary
        {
            Source = new Uri("StringResources.en.xaml", UriKind.Relative)
        };

        Resources.MergedDictionaries.Add(englishDictionary);
    }
}


