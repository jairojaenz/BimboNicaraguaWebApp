using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Indicador
    {
        public Indicador()
        {
            IndicadorDatos = new HashSet<IndicadorDato>();
            Meta = new HashSet<Metum>();
        }

        public int IndicadorId { get; set; }
        public string Nombre { get; set; } = null!;
        public int ObjetivoId { get; set; }
        public int TipoId { get; set; }

        public virtual Objetivo Objetivo { get; set; } = null!;
        public virtual Tipo Tipo { get; set; } = null!;
        public virtual ICollection<IndicadorDato> IndicadorDatos { get; set; }
        public virtual ICollection<Metum> Meta { get; set; }
    }
}
