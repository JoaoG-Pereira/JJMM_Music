using System;
using System.Collections.Generic;

namespace JJMM_Music.Models
{
    public partial class Musica
    {
        public int IdMusica { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public short? Duracao { get; set; }
        public string Link { get; set; }
        public int? IdAlbum { get; set; }

        public Album IdAlbumNavigation { get; set; }
    }
}
