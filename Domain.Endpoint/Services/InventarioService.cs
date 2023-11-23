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

        public void DeleteInV(Guid Id)
        {
           _inventarioRepository.DeleteInV(Id);
        }

        public Task<List<Inventario>> GetInV()
        {
          return _inventarioRepository.GetInV();
        }

        public void UpdateInV(Guid Id, Inventario nuevosRegistros)
        {
           _inventarioRepository.UpdateInV(Id, nuevosRegistros);
        }
    }
}
