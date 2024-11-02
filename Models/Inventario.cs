using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Inventario
    {
        public int InventarioId { get; set; }
        public int? ProductoId { get; set; }
        public int? CantidadDisponible { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Producto? Producto { get; set; }
    }
}
