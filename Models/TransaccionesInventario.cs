using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class TransaccionesInventario
    {
        public TransaccionesInventario()
        {
            DetalleTransaccionInventarios = new HashSet<DetalleTransaccionInventario>();
        }

        public int TransaccionId { get; set; }
        public int? ProductoId { get; set; }
        public string? Tipo { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaTransaccion { get; set; }

        public virtual Producto? Producto { get; set; }
        public virtual ICollection<DetalleTransaccionInventario> DetalleTransaccionInventarios { get; set; }
    }
}
