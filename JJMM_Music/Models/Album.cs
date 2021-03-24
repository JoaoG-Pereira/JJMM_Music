using System;
using System.Collections.Generic;

namespace JJMM_Music.Models
{
    public partial class Album
    {
        public Album()
        {
            Musica = new HashSet<Musica>();
        }

        public int IdAlbum { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public int? IdBanda { get; set; }

        public Banda IdBandaNavigation { get; set; }
        public ICollection<Musica> Musica { get; set; }
    }
}
