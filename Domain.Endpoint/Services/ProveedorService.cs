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

        public async Task DeleteProveedor(Guid Id)
        {
          await  _proveedorRepository.DeleteProveedor(Id);
        }

        public Task<List<Proveedor>> GetAll()
        {
            return _proveedorRepository.Get();
        }

        public Task<Proveedor> GetById(Guid Id)
        {
           return _proveedorRepository.GetById(Id);
        }

        public async Task UpdateProveedor(Guid Id, Proveedor nuevoRegistros)
        {
           await _proveedorRepository.UpdateProveedor(Id, nuevoRegistros);
        }
    }
}
