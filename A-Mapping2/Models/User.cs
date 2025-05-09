using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Mapping2.Models
{
    class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<MapaMental> MapasMentais { get; set; } = new List<MapaMental>();

        public string ProfilePicturePath { get; set; } 
    }
}
