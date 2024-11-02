using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class DetalleRutum
    {
        public int DetalleRutaId { get; set; }
        public int? RutaId { get; set; }
        public int? PedidoId { get; set; }

        public virtual Pedido? Pedido { get; set; }
        public virtual Ruta? Ruta { get; set; }
    }
}
