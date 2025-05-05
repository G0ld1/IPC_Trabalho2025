using A_MappingTrabalho.Contracts.Services;
using A_MappingTrabalho.Contracts.Views;
using A_MappingTrabalho.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using A_MappingTrabalho.Views;

namespace A_MappingTrabalho.ViewModels
{
    public class LoginViewModel : Observable
    {

        private readonly INavigationService _navigationService;

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new RelayCommand(OnLogin);
            NavigateToRegisterCommand = new RelayCommand(OnNavigateToRegister);
        }

        private void OnLogin()
        {
            // Aqui deverias validar credenciais...

            // Se estiver tudo ok, abrir a ShellWindow:
            var shell = AppServices.GetService<IShellWindow>();
            shell.ShowWindow();

            // Fechar a janela de login
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is LoginWindow)?.Close();
        }

        private void OnNavigateToRegister()
        {
            //_navigationService.NavigateTo(typeof(RegisterViewModel).FullName);
        }
    }
}
