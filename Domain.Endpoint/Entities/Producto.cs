using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Producto : BaseEntity
    {
        [Required(ErrorMessage = "El  Nombre del Producto es obligatorio.")]
        public string NombreProducto { get; set; }
        [StringLength(15, ErrorMessage = "La longitud máxima para Lote es de 15 caracteres.")]
        public string Descripcion { get; set; }
        public Guid IdCategoria { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El Precio de Compra debe ser un número positivo.")]
        public int Preciocompra { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El Precio de Venta debe ser un número positivo.")]
        public int Precioventa { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El estado debe ser un número positivo.")]
        public int Estado { get; set; }
        public DateTime FechaCompra { get; set; }
        [Required(ErrorMessage = "La Fecha de vencimiento es obligatorio.")]
        public DateTime FechaVencimiento { get; set; }
    }
}

