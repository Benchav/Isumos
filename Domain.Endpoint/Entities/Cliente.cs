using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Cliente:BaseEntity
    {

        [Required(ErrorMessage = "El Primer Nombre es obligatorio.")]

        public string PrimerNombre { get; set; }

        [StringLength(15, ErrorMessage = "La longitud máxima para Segundo Nombre es de 15 caracteres.")]
        public string SegundoNombre { get; set; }


        [Required(ErrorMessage = "El Primer Apellido es obligatorio.")]
        public string PrimerApellido { get; set; }


        [StringLength(15, ErrorMessage = "La longitud máxima para Segundo Apellido es de 15 caracteres.")]
        public string SegundoApellido { get; set; }


        [Required(ErrorMessage = "El Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe de cumplir como correo.")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "El Telefono es obligatorio.")]
        public string Telefono { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "El Estado debe ser un número positivo.")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "La fecha  es obligatorio.")]

        public DateTime FechaCreacion { get; set; }
       


    }
}
