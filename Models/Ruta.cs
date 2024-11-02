using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            DetalleRuta = new HashSet<DetalleRutum>();
            EntregaProductos = new HashSet<EntregaProducto>();
        }

        public int RutaId { get; set; }
        public string? Descripcion { get; set; }
        public int? EmpleadoId { get; set; }
        public DateTime? FechaRuta { get; set; }
        public string? Horario { get; set; }
        public int? CamionId { get; set; }

        public virtual Camione? Camion { get; set; }
        public virtual Empleado? Empleado { get; set; }
        public virtual ICollection<DetalleRutum> DetalleRuta { get; set; }
        public virtual ICollection<EntregaProducto> EntregaProductos { get; set; }
    }
}
