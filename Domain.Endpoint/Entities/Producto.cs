using System;

namespace Domain.Endpoint.Entities
{
    public class Producto : BaseEntity
    {
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public Guid IdCategoria { get; set; }   
        public int Preciocompra { get; set; }
        public int Precioventa { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}

