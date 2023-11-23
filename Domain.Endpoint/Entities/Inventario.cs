using System;

namespace Domain.Endpoint.Entities
{
    public class Inventario : BaseEntity
    {
        public Guid IdProductoDetalle {  get; set; }
        public string Proveedor { get; set; }
        public int Existencia { get; set; }
        public string Lote { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra {  get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
