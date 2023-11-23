using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Cliente:BaseEntity
    {
      
        [Required]
        [StringLength(50)]
        public string PrimerNombre { get; set; }

    
        [MaxLength(10)]
        public string SegundoNombre { get; set; }
        [Required]
        [MaxLength(10)]
        public string PrimerApellido { get; set; }

        [MaxLength(10)]
        public string SegundoApellido { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        
        [Required,StringLength(8)]
        public string Telefono { get; set; }

        [Required]
        public int Estado { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }



    }
}
