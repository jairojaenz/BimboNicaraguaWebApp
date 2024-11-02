using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            Indicadors = new HashSet<Indicador>();
        }

        public int ObjetivoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int CmiId { get; set; }
        public int PerspectivaId { get; set; }

        public virtual CMI CMI { get; set; } = null!;
        public virtual Perspectiva Perspectiva { get; set; } = null!;
        public virtual ICollection<Indicador> Indicadors { get; set; }
    }
}
