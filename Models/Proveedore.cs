using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Proveedore
    {
        public int ProveedorId { get; set; }
        public string? NombreProveedor { get; set; }
        public string? Contacto { get; set; }
        public string? Ubicacion { get; set; }
    }
}
