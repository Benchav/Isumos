using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Inventario : BaseEntity
    {
        public Guid IdProductoDetalle {  get; set; }
        [Required(ErrorMessage = "El  Proveedor es obligatorio.")]
        public string Proveedor { get; set; }
        [Required(ErrorMessage = "La Existencia es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "La Existencia debe ser un número positivo.")]
        public int Existencia { get; set; }
        [StringLength(15, ErrorMessage = "La longitud máxima para Lote es de 15 caracteres.")]
        public string Lote { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El Precio de Venta debe ser un número positivo.")]
        public decimal PrecioVenta { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El Precio de Compra debe ser un número positivo.")]
        public decimal PrecioCompra {  get; set; }
        public DateTime FechaCompra { get; set; }
        [Required(ErrorMessage = "La Fecha de Vencimiento es obligatoria.")]
        public DateTime FechaVencimiento { get; set; }
    }
}
