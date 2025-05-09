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
using A_Mapping2.Models;

namespace A_Mapping2.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

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
            if (param is object[] passwordBoxes &&
                passwordBoxes[0] is PasswordBox passwordBox &&
                passwordBoxes[1] is PasswordBox confirmBox)
            {
                string password = passwordBox.Password;
                string confirmPassword = confirmBox.Password;

                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email))
                {
                    MessageBox.Show("Preencha todos os campos.");
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("As palavras-passe não coincidem.");
                    return;
                }

                bool success = UserDataStore.Register(Username, Email, password);
                if (!success)
                {
                    MessageBox.Show("Já existe um utilizador registado.");
                    return;
                }

                MessageBox.Show("Utilizador registado com sucesso!");
                _navigationFrame.Navigate(new LoginPage(_navigationFrame));
            }
        }

    }
}
