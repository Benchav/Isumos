using System;

namespace Domain.Endpoint.Entities
{

    public class Proveedor : BaseEntity
    {
        public string NombreCompañia { get; set; }
        public string Correo { get; set; }
        public int Telefono{ get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

       
    }
}
