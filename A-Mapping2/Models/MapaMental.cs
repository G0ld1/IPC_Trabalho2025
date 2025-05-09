using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Mapping2.Models
{
    public class MapaMental
    {
        public string Titulo { get; set; }
        public string ImagemPath { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public string GrupoCronologico
        {
            get
            {

                var hoje = DateTime.Today;
                if (DataCriacao.Date == hoje) { return "Hoje"; }
                if (DataCriacao.Date == hoje.AddDays(-1)) return "Ontem";
                if (DataCriacao >= hoje.AddDays(-7)) return "Últimos 7 dias";
                return "Mais antigos";
            }
        }
    }
}
