using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using A_MappingTrabalho.Contracts.Services;
using A_MappingTrabalho.Helpers;
using A_MappingTrabalho.Properties;

using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;

namespace A_MappingTrabalho.ViewModels
{
    public class ShellViewModel : Observable
    {
        private readonly INavigationService _navigationService;
        private object _selectedMenuItem;
        private RelayCommand _goBackCommand;
        private ICommand _menuItemInvokedCommand;
        private ICommand _loadedCommand;
        private ICommand _unloadedCommand;

        public object SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (value as NavigationPaneItem == null)
                {
                    Set(ref _selectedMenuItem, ((FrameworkElement)value).DataContext, "SelectedMenuItem");
                }
                else
                {
                    Set(ref _selectedMenuItem, value, "SelectedMenuItem");
                }
                //NavigateTo((_selectedMenuItem as NavigationPaneItem).TargetType);
				if (_selectedMenuItem is NavigationPaneItem navigationPaneItem && navigationPaneItem.TargetType != null)
                {
                    NavigateTo(navigationPaneItem.TargetType);
                }
            }
        }

        public void UpdateFillColor(SolidColorBrush FillColor)
        {
            foreach (var item in MenuItems)
            {
                (item as NavigationPaneItem).Path.Fill = FillColor;
            }
            SetttingsIconColor = FillColor;
        }

        private SolidColorBrush setttingsIconColor;

        public SolidColorBrush SetttingsIconColor
        {
            get { return setttingsIconColor; }
            set
            {
                setttingsIconColor = value;
                OnPropertyChanged(nameof(SetttingsIconColor));
            }
        }

        // TODO WTS: Change the icons and titles for all HamburgerMenuItems here.
        public ObservableCollection<NavigationPaneItem> MenuItems { get; set; } = new ObservableCollection<NavigationPaneItem>()
        {
        	new NavigationPaneItem() { 
                        Label = Resources.ShellMainPage,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse("M28.414 4H7V44H39V14.586ZM29 7.414 35.586 14H29ZM9 42V6H27V16H37V42Z"),
                            Fill = new SolidColorBrush(Colors.Black),
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(MainViewModel) 
            },
        	new NavigationPaneItem() { 
                        Label = Resources.ShellNavigationDrawerPage,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse("M6 2C3.79086 2 2 3.79086 2 6V34C2 36.2091 3.79086 38 6 38H22V2H6ZM24 2V38H42C44.2091 38 46 36.2091 46 34V6C46 3.79086 44.2091 2 42 2H24ZM0 6C0 2.68629 2.68629 0 6 0H23H42C45.3137 0 48 2.68629 48 6V34C48 37.3137 45.3137 40 42 40H23H6C2.68629 40 0 37.3137 0 34V6ZM6 8C6 7.44772 6.44772 7 7 7H18C18.5523 7 19 7.44772 19 8C19 8.55229 18.5523 9 18 9H7C6.44772 9 6 8.55229 6 8ZM7 15C6.44772 15 6 15.4477 6 16C6 16.5523 6.44772 17 7 17H18C18.5523 17 19 16.5523 19 16C19 15.4477 18.5523 15 18 15H7ZM6 24C6 23.4477 6.44772 23 7 23H18C18.5523 23 19 23.4477 19 24C19 24.5523 18.5523 25 18 25H7C6.44772 25 6 24.5523 6 24ZM7 31C6.44772 31 6 31.4477 6 32C6 32.5523 6.44772 33 7 33H18C18.5523 33 19 32.5523 19 32C19 31.4477 18.5523 31 18 31H7Z"),
                            Fill = new SolidColorBrush(Colors.Black),
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(NavigationDrawerViewModel) 
            },
        };

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SetttingsIconColor = new SolidColorBrush(Colors.Black);
        }

        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
        }

        private void OnUnloaded()
        {
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void NavigateTo(Type targetViewModel)
        {
            if (targetViewModel != null)
            {
                _navigationService.NavigateTo(targetViewModel.FullName);
            }
        }

        private void OnNavigated(object sender, string viewModelName)
        {
            var item = MenuItems
                        .OfType<NavigationPaneItem>()
                        .FirstOrDefault(i => viewModelName == i.TargetType?.FullName);
            if (item != null)
            {
                SelectedMenuItem = item;
            }

            GoBackCommand.OnCanExecuteChanged();
        }
    }

    public class NavigationPaneItem
    {
        public string Label { get; set; }
        public Path Path { get; set; }
        public Type TargetType { get; set; }

    }
}
