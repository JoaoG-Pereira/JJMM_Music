using System;
using System.Collections.Generic;

namespace JJMM_Music.Models
{
    public partial class Show
    {
        public Show()
        {
            Ingresso = new HashSet<Ingresso>();
        }

        public int IdShow { get; set; }
        public DateTime? Data { get; set; }
        public string Local { get; set; }
        public int? IdBanda { get; set; }

        public Banda IdBandaNavigation { get; set; }
        public ICollection<Ingresso> Ingresso { get; set; }
    }
}
