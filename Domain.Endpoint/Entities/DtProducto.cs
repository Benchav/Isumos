using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public  class DtProducto : BaseEntity
    {
        
        public Guid IdProducto { get; set; }
        [Required(ErrorMessage = "La Descripcion es obligatorio.")]
        public string Descripcion { get; set; }
        [StringLength(10, ErrorMessage = "La longitud máxima para Marca es de 10 caracteres.")]
        public string Marca { get; set; }
      
        [Required(ErrorMessage = "La Medida es obligatorio.")]
        public string Medida { get; set; }
       
        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El Estado debe ser un número positivo.")]
        public int Estado { get; set; }
    }
}
