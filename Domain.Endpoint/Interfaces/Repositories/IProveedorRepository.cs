using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IProveedorRepository
    {
        Task<List<Proveedor>> Get();
        Task<Proveedor> GetById(Guid Id);
        void CreateProveedor(Proveedor nuevoProveedor);

        void DeleteProveedor(Guid Id);

        void UpdateProveedor(Guid Id, Proveedor nuevoProv);
    }
}
