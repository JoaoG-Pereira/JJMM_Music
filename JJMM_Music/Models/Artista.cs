using System;
using System.Collections.Generic;

namespace JJMM_Music.Models
{
    public partial class Artista
    {
        public int IdArtista { get; set; }
        public string Nome { get; set; }
        public string Instrumento { get; set; }
        public short? Idade { get; set; }
        public string Pais { get; set; }
        public string Descricao { get; set; }
        public int? IdBanda { get; set; }

        public Banda IdBandaNavigation { get; set; }
    }
}
