using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class EntregaProducto
    {
        public EntregaProducto()
        {
            DetalleEntregas = new HashSet<DetalleEntrega>();
        }

        public int EntregaId { get; set; }
        public int? ClienteId { get; set; }
        public int? ProductoId { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int? CantidadEntregada { get; set; }
        public string? Estado { get; set; }
        public int? RutaId { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual Producto? Producto { get; set; }
        public virtual Ruta? Ruta { get; set; }
        public virtual ICollection<DetalleEntrega> DetalleEntregas { get; set; }
    }
}
