using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using A_Mapping2.Models;
using System.Windows;

namespace A_Mapping2.Helpers
{
    class UserDataStore
    {
        private static readonly string FilePath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    "A_Mapping2",
    "userdata.json");

        public static User CurrentUser { get; private set; }


        public static void AddFakeMindMapsToUser(string username)
        {
            var users = LoadAllUsers();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                user.MapasMentais.AddRange(new List<MapaMental>
        {
            new MapaMental { Titulo = "Mapa: Desafio 3- Simplificar", ImagemPath = "/Assets/mapa1.png", DataCriacao = DateTime.Today },
            new MapaMental { Titulo = "Mapa: Algoritmia- BinaryTrees", ImagemPath = "/Assets/mapa2.png", DataCriacao = DateTime.Today.AddDays(-2) },
            new MapaMental { Titulo = "Mapa: Ideias App", ImagemPath = "/Assets/mapa3.png", DataCriacao = DateTime.Today.AddDays(-10) }
        });

                SaveAllUsers(users);
            }
        }

        private static List<User> LoadAllUsers()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            if (!File.Exists(FilePath))
                return new List<User>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        private static void SaveAllUsers(List<User> users)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static void SaveCurrentUser()
        {
            if (CurrentUser == null) return;

            var users = LoadAllUsers();
            var existingUser = users.FirstOrDefault(u => u.Username == CurrentUser.Username);

            if (existingUser != null)
            {
                existingUser.Email = CurrentUser.Email;
                existingUser.Password = CurrentUser.Password;
                existingUser.MapasMentais = CurrentUser.MapasMentais;
                existingUser.ProfilePicturePath = CurrentUser.ProfilePicturePath; 
            }
        

            SaveAllUsers(users);
        }

        public static bool Register(string username, string email, string password)
        {
            var users = LoadAllUsers();

            // Verifica se já existe utilizador com mesmo username ou email
            if (users.Any(u => u.Username == username || u.Email == email))
                return false;

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                MapasMentais = new List<MapaMental>()
            };

            users.Add(user);
            SaveAllUsers(users);

            CurrentUser = user;
            return true;
        }

        public static bool Login(string usernameOrEmail, string password)
        {
            var users = LoadAllUsers();

            var user = users.FirstOrDefault(u =>
                (u.Username == usernameOrEmail || u.Email == usernameOrEmail) &&
                u.Password == password);

            if (user != null)
            {
                CurrentUser = user;

                Properties.Settings.Default.LoggedUsername = user.Username;
                Properties.Settings.Default.IsLoggedIn = true;
                Properties.Settings.Default.Save();
                return true;
            }

            return false;
        }

        public static void UpdatePassword(string newPassword)
        {
            if (CurrentUser == null) return;

            var users = LoadAllUsers();
            var user = users.FirstOrDefault(u => u.Username == CurrentUser.Username);

            if (user != null)
            {
                user.Password = newPassword;
                SaveAllUsers(users);
                CurrentUser = user; // atualiza instância atual
            }
        }

        public static void LoadUser()
        {
            if (!Properties.Settings.Default.IsLoggedIn)
                return;

            string username = Properties.Settings.Default.LoggedUsername;
            var users = LoadAllUsers();

            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                CurrentUser = user;
            }
        }

        public static void Logout()
        {
            CurrentUser = null;
            Properties.Settings.Default.IsLoggedIn = false;
            Properties.Settings.Default.LoggedUsername = string.Empty;
            Properties.Settings.Default.Save();
        }
    }
}
