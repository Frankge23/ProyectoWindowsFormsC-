using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ClaseEntidades
    {
        public class Trabajador
        {
            public int IdTrabajador { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Sexo { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string NumeroDocumento { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
        }

        public class Proveedor
        {
            public int IdProveedor { get; set; }
            public string NombreProveedor { get; set; }
            public string SectorComercial { get; set; }
            public string TipoDocumento { get; set; }
            public string NumeroDocumento { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
        }

        public class Categoria
        {
            public int IdCategoria { get; set; }
            public string TipoCategoria { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
        }

        public class Cliente
        {
            public int IdCliente { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Sexo { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string TipoDocumento { get; set; }
            public string NumeroDocumento { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
        }

        public class Articulo
        {
            public int IdArticulo { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public int IdCategoria { get; set; }
            public string TipoCategoria { get; set; }
        }

        public class Ingreso
        {
            public int IdIngreso { get; set; }
            public int IdTrabajador { get; set; }
            public int IdProveedor { get; set; }
            public DateTime FechaIngreso { get; set; }
            public string TipoComprobante { get; set; }
            public string Serie { get; set; }
            public string Correlativo { get; set; }
            public string Estado { get; set; }
        }

        public class Venta
        {
            public int IdVenta { get; set; }
            public int IdCliente { get; set; }
            public int IdTrabajador { get; set; }
            public DateTime FechaVenta { get; set; }
            public string TipoComprobante { get; set; }
            public string Serie { get; set; }
            public string Correlativo { get; set; }
            public decimal PrecioTotal { get; set; }
        }

        public class DetalleIngreso
        {
            public int IdDetalleIngreso { get; set; }
            public int IdIngreso { get; set; }
            public int IdArticulo { get; set; }
            public decimal PrecioCompra { get; set; }
            public int StockInicial { get; set; }
            public int StockActual { get; set; }
            public decimal Descuento { get; set; }
        }

        public class DetalleVenta
        {
            public int IdDetalleVenta { get; set; }
            public int IdVenta { get; set; }
            public int IdDetalleIngreso { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioVenta { get; set; }
            public decimal Descuento { get; set; }
        }

    }
}
