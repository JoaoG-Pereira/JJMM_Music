using System;
using System.Collections.Generic;

namespace JJMM_Music.Models
{
    public partial class Banda
    {
        public Banda()
        {
            Album = new HashSet<Album>();
            Artista = new HashSet<Artista>();
            Show = new HashSet<Show>();
        }

        public int IdBanda { get; set; }
        public string NomeBanda { get; set; }
        public int? IdGenero { get; set; }

        public Genero IdGeneroNavigation { get; set; }
        public ICollection<Album> Album { get; set; }
        public ICollection<Artista> Artista { get; set; }
        public ICollection<Show> Show { get; set; }
    }
}
