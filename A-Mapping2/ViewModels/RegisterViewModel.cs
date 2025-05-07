using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_Mapping2.Helpers;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using A_Mapping2.Views.Pages;

namespace A_Mapping2.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        public string Username { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand BackToLoginCommand { get; }

        private readonly Frame _navigationFrame;

        public RegisterViewModel(Frame navigationFrame)
        {
            _navigationFrame = navigationFrame;
            RegisterCommand = new RelayCommand<object>(Register);
            BackToLoginCommand = new RelayCommand<object>(_ => _navigationFrame.GoBack());
        }

        private void Register(object param)
        {
            if (param is PasswordBox passwordBox)
            {
                var password = passwordBox.Password;
                // Aqui podias guardar o novo user ou simular criação

                MessageBox.Show("Utilizador registado com sucesso!");
                _navigationFrame.Navigate(new LoginPage(_navigationFrame));
            }
        }

    }
}
