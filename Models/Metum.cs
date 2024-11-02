using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Metum
    {
        public int MetaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal ValorEsperado { get; set; }
        public DateTime FechaLimite { get; set; }
        public int IndicadorId { get; set; }

        public virtual Indicador Indicador { get; set; } = null!;
    }
}
