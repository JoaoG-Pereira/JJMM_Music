using System;
using System.Collections.Generic;

namespace JJMM_Music.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Banda = new HashSet<Banda>();
        }

        public int IdGenero { get; set; }
        public string NomeGenero { get; set; }
        public string Descricao { get; set; }

        public ICollection<Banda> Banda { get; set; }
    }
}
