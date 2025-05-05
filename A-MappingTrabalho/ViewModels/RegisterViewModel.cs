using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using A_MappingTrabalho.Contracts.Views;
using A_MappingTrabalho.Helpers;
using A_MappingTrabalho.Views;

namespace A_MappingTrabalho.ViewModels
{
    public class RegisterViewModel : Observable
    {
        private string _username;
        private string _email;
        private string _password;
        private string _confirmPassword;

        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }
        
           

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => Set(ref _confirmPassword, value);
        }

        public ICommand RegisterCommand { get; }
        public ICommand BackToLoginCommand { get; }


        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(OnRegister);
            BackToLoginCommand = new RelayCommand(OnBackToLogin);
        }

        private void OnRegister()
        {
            // Lógica simples de validação
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }

            if (Password != ConfirmPassword)
            {
                MessageBox.Show("As passwords não coincidem.");
                return;
            }

           
            MessageBox.Show("Registo concluído!");

            // Voltar ao login
            OnBackToLogin();
        }

        private void OnBackToLogin()
        {
            var loginWindow = App.Current is App app ? app.GetService<LoginWindow>() : null;
          

            // Fecha a janela de registo
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is RegisterWindow)?.Close();
        }

    }
}
