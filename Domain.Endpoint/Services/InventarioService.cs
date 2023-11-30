using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public Inventario CreateInV(Inventario Ninventario)
        {
            Inventario newInventario = new Inventario()
            {
                Id = Guid.NewGuid(),
                IdProductoDetalle=Guid.NewGuid(),
                Proveedor=Ninventario.Proveedor,
                Existencia=Ninventario.Existencia,
                Lote=Ninventario.Lote,
                PrecioVenta=Ninventario.PrecioVenta,
                PrecioCompra=Ninventario.PrecioCompra,
                FechaCompra=Ninventario.FechaCompra,
                FechaVencimiento=Ninventario.FechaVencimiento
            };
            _inventarioRepository.CreateInV(newInventario);
            return newInventario;
        }

        public async Task DeleteInV(Guid Id)
        {
          await _inventarioRepository.DeleteInV(Id);
        }

        public Task<Inventario> GetById(Guid Id)
        {
           return _inventarioRepository.GetById(Id);
        }

        public Task<List<Inventario>> GetInV()
        {
          return _inventarioRepository.GetInV();
        }

        public async Task UpdateInV(Guid Id, Inventario nuevosRegistros)
        {
         await   _inventarioRepository.UpdateInV(Id, nuevosRegistros);
        }
    }
}
