using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public Proveedor CreateProveedor(Proveedor nuevoProveedor)
        {
            Proveedor newProveedor = new Proveedor()
            {
                Id = Guid.NewGuid(),
                NombreCompañia = nuevoProveedor.NombreCompañia,
                Correo = nuevoProveedor.Correo,
                Telefono = nuevoProveedor.Telefono,
                Estado = nuevoProveedor.Estado,
                FechaCreacion = nuevoProveedor.FechaCreacion
            };

            _proveedorRepository.CreateProveedor(newProveedor);
            return newProveedor;
        }

        public void DeleteProveedor(Guid Id)
        {
            _proveedorRepository.DeleteProveedor(Id);
        }

        public Task<List<Proveedor>> GetAll()
        {
            return _proveedorRepository.Get();
        }

        public void UpdateProveedor(Guid Id, Proveedor nuevoRegistros)
        {
            _proveedorRepository.UpdateProveedor(Id, nuevoRegistros);
        }
    }
}
