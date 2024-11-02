using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int MunicipioId { get; set; }
        public string? NombreMunicipio { get; set; }
        public int? DepartamentoId { get; set; }

        public virtual Departamento? Departamento { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
