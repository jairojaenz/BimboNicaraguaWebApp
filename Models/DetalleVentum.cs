﻿using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class DetalleVentum
    {
        public int DetalleId { get; set; }
        public int? VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }

        public virtual Producto? Producto { get; set; }
        public virtual Venta? Venta { get; set; }
    }
}
