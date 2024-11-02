using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class DetalleTransaccionInventario
    {
        public int DetalleTransaccionId { get; set; }
        public int? TransaccionId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }

        public virtual Producto? Producto { get; set; }
        public virtual TransaccionesInventario? Transaccion { get; set; }
    }
}
