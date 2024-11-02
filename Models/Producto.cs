using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleEntregas = new HashSet<DetalleEntrega>();
            DetallePedidos = new HashSet<DetallePedido>();
            DetalleTransaccionInventarios = new HashSet<DetalleTransaccionInventario>();
            DetalleVenta = new HashSet<DetalleVentum>();
            EntregaProductos = new HashSet<EntregaProducto>();
            Inventarios = new HashSet<Inventario>();
            TransaccionesInventarios = new HashSet<TransaccionesInventario>();
        }

        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<DetalleEntrega> DetalleEntregas { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<DetalleTransaccionInventario> DetalleTransaccionInventarios { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<EntregaProducto> EntregaProductos { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<TransaccionesInventario> TransaccionesInventarios { get; set; }
    }
}
