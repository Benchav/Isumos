using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IProveedorService
    {


        Task<List<Proveedor>> GetAll();

        Proveedor CreateProveedor(Proveedor nuevoProveedor);

        void DeleteProveedor(Guid Id);

        void UpdateProveedor(Guid Id, Proveedor nuevoRegistros);



    }
}
