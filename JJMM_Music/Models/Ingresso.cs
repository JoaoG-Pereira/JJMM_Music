using System;
using System.Collections.Generic;

namespace JJMM_Music.Models
{
    public partial class Ingresso
    {
        public int IdIngresso { get; set; }
        public string Setor { get; set; }
        public float? Valor { get; set; }
        public string Descricao { get; set; }
        public int? IdShow { get; set; }

        public Show IdShowNavigation { get; set; }
    }
}
