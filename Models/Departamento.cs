using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Municipios = new HashSet<Municipio>();
        }

        public int DepartamentoId { get; set; }
        public string? NombreDepartamento { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
