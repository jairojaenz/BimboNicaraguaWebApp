using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class DetalleEntrega
    {
        public int DetalleEntregaId { get; set; }
        public int? EntregaId { get; set; }
        public int? ProductoId { get; set; }
        public int? CantidadEntregada { get; set; }

        public virtual EntregaProducto? Entrega { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
