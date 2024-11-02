using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Ruta = new HashSet<Ruta>();
        }

        public int EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Puesto { get; set; }
        public string? Departamento { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public decimal? Salario { get; set; }

        public virtual ICollection<Ruta> Ruta { get; set; }
    }
}
