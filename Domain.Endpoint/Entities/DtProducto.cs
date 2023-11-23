using System;

namespace Domain.Endpoint.Entities
{
    public  class DtProducto : BaseEntity
    {
        
        public Guid IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Medida { get; set; }
        public int Estado { get; set; }
    }
}
