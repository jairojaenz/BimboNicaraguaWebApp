using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Perspectiva
    {
        public Perspectiva()
        {
            Objetivos = new HashSet<Objetivo>();
        }

        public int PerspectivaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Objetivo> Objetivos { get; set; }
    }
}
