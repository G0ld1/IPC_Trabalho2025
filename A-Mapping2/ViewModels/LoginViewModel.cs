using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using A_Mapping2.Helpers;
using A_Mapping2.Views.Pages;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace A_Mapping2.ViewModels
{
    class LoginViewModel: BaseViewModel
    {
        public string Username { get; set; }
        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        private readonly Frame _navigationFrame;

        public event PropertyChangedEventHandler PropertyChanged;


        public LoginViewModel(Frame navigationFrame)
        {
            _navigationFrame = navigationFrame;
            LoginCommand = new RelayCommand<string>(DoLogin);
            NavigateToRegisterCommand = new RelayCommand<object>(_ => _navigationFrame.Navigate(new RegisterPage(_navigationFrame)));

        }

        private void DoLogin(string _)
        {
            if (Username == "admin" && Password == "123")
            {
                _navigationFrame.Navigate(new HomePage(_navigationFrame, Username));
            }
            else
            {
                ErrorMessage = "Invalid username or password.";

            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
