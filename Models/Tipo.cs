using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Indicadors = new HashSet<Indicador>();
        }

        public int TipoId { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Indicador> Indicadors { get; set; }
    }
}
