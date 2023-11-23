using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Cat : BaseEntity
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Estado { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }


    }
}
