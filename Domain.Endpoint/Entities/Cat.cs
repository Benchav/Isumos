using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Cat : BaseEntity
    {
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El Estado debe ser un número positivo.")]
        public int Estado { get; set; }
        [Required(ErrorMessage = "El campo FechaCrecion es obligatorio.")]
        public DateTime FechaCreacion { get; set; }
      


    }
}
