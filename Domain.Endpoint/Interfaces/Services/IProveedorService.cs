using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IProveedorService
    {


        Task<List<Proveedor>> GetAll();
        Task<Proveedor> GetById(Guid Id);
        Proveedor CreateProveedor(Proveedor nuevoProveedor);

        Task DeleteProveedor(Guid Id);

       Task UpdateProveedor(Guid Id, Proveedor nuevoRegistros);



    }
}
