using System.Windows.Controls;
using System.Windows;

namespace A_Mapping2.Views.Controls
{
    public partial class LanguageSelector : UserControl
    {
        public LanguageSelector()
        {
            InitializeComponent();
            Loaded += LanguageSelector_Loaded;
        }

        private void LanguageSelector_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the selected language based on the current language in the App class
            var app = (App)Application.Current;
            foreach (ComboBoxItem item in LanguageComboBox.Items)
            {
                if (item.Tag.ToString() == app.CurrentLanguage)
                {
                    item.IsSelected = true;
                    break;
                }
            }
        }

        private void LanguageSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is ComboBoxItem selectedItem)
            {
                string languageCode = selectedItem.Tag.ToString();
                ((App)Application.Current).CurrentLanguage = languageCode;
            }
        }
    }
}