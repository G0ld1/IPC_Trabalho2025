using A_Mapping2.Helpers;
using A_Mapping2.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace A_Mapping2.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public string Username { get; set; } = "Utilizador123";
        public string Email { get; set; } = "utilizador@email.com";

      

        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set => SetProperty(ref _isPopupOpen, value);
        }

        public void UpdatePassword(string newPassword)
        {
            // Aqui chamamos o método UserDataStore para atualizar a password
            if (UserDataStore.CurrentUser != null)
            {
                UserDataStore.UpdatePassword(newPassword);
                MessageBox.Show("Palavra-passe atualizada com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro: Utilizador não encontrado.");
            }
        }

       
    }
}
