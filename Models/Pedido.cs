using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
            DetalleRuta = new HashSet<DetalleRutum>();
        }

        public int PedidoId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? FechaPedido { get; set; }
        public string? Estado { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<DetalleRutum> DetalleRuta { get; set; }
    }
}
