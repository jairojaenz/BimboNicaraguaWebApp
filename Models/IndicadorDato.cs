using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class IndicadorDato
    {
        public int IndicaDatoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int IndicadorId { get; set; }

        public virtual Indicador Indicador { get; set; } = null!;
    }
}
