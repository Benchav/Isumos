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
        Task CreateProveedor(Proveedor nuevoProveedor);

        Task DeleteProveedor(Guid Id);

        Task UpdateProveedor(Guid Id, Proveedor nuevoProv);
    }
}
