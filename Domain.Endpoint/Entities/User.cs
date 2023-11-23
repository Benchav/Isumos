using System;

namespace Domain.Endpoint.Entities
{
    public class User:BaseEntity
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public Guid IdRol { get; set; } 
        public int Estado { get; set; }
        public string Sexo { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
