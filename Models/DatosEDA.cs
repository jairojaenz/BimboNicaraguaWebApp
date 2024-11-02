using Newtonsoft.Json;

namespace BimboNicaragua.Models
{
    public class DatosEDA
    {
        [JsonProperty("Cantidad Venta")]
        public int CantidadVenta { get; set; }

        [JsonProperty("Categoria Producto")]
        public string CategoriaProducto { get; set; }

        [JsonProperty("Contacto Cliente")]
        public string ContactoCliente { get; set; }

        [JsonProperty("Contacto Proveedor")]
        public string ContactoProveedor { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Date Key")]
        public int DateKey { get; set; }

        [JsonProperty("Departamento Cliente")]
        public string DepartamentoCliente { get; set; }

        [JsonProperty("Descripcion Producto")]
        public string DescripcionProducto { get; set; }

        [JsonProperty("Municipio Cliente")]
        public string MunicipioCliente { get; set; }

        [JsonProperty("Nombre Cliente")]
        public string NombreCliente { get; set; }

        [JsonProperty("Nombre Producto")]
        public string NombreProducto { get; set; }

        [JsonProperty("Nombre Proveedor")]
        public string NombreProveedor { get; set; }

        [JsonProperty("Precio Producto")]
        public string PrecioProducto { get; set; }

        [JsonProperty("Precio Unitario")]
        public double PrecioUnitario { get; set; }

        [JsonProperty("Tipo Cliente")]
        public string TipoCliente { get; set; }

        [JsonProperty("Ubicacion Cliente")]
        public string UbicacionCliente { get; set; }

        [JsonProperty("Ubicacion Proveedor")]
        public string UbicacionProveedor { get; set; }
    }
}
