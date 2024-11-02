using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
            Facturas = new HashSet<Factura>();
        }

        public int VentaId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
