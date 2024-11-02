using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class CuentasPorCobrar
    {
        public int CuentaId { get; set; }
        public int? ClienteId { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Estado { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
