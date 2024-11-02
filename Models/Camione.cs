using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Camione
    {
        public Camione()
        {
            Ruta = new HashSet<Ruta>();
        }

        public int CamionId { get; set; }
        public string? Matricula { get; set; }
        public int? Capacidad { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Ruta> Ruta { get; set; }
    }
}
