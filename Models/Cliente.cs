using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CuentasPorCobrars = new HashSet<CuentasPorCobrar>();
            EntregaProductos = new HashSet<EntregaProducto>();
            Pedidos = new HashSet<Pedido>();
            Venta = new HashSet<Venta>();
        }

        public int ClienteId { get; set; }
        public string? NombreCliente { get; set; }
        public string? Tipo { get; set; }
        public string? Contacto { get; set; }
        public string? Ubicacion { get; set; }
        public int? MunicipioId { get; set; }

        public virtual Municipio? Municipio { get; set; }
        public virtual ICollection<CuentasPorCobrar> CuentasPorCobrars { get; set; }
        public virtual ICollection<EntregaProducto> EntregaProductos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
