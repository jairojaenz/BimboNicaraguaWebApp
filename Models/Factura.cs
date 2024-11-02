using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Factura
    {
        public int FacturaId { get; set; }
        public int? VentaId { get; set; }
        public DateTime? FechaFactura { get; set; }
        public decimal? TotalFactura { get; set; }

        public virtual Venta? Venta { get; set; }
    }
}
