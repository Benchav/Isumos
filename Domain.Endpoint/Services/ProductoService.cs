using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Services;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository ProductoRepository)
        {
            _productoRepository = ProductoRepository;
        }

        public Producto CreateProducto(Producto nuevoProducto)
        {

             Producto newProducto = new Producto()
             {
                 Id = Guid.NewGuid(),
                 NombreProducto = nuevoProducto.NombreProducto,
                 Descripcion = nuevoProducto.Descripcion,
                 IdCategoria = Guid.NewGuid(),
                 Preciocompra = nuevoProducto.Preciocompra,
                 Precioventa = nuevoProducto.Precioventa,
                 Estado = nuevoProducto.Estado,
                 FechaCompra= nuevoProducto.FechaCompra,
                 FechaVencimiento = nuevoProducto.FechaVencimiento
             };
             _productoRepository.CreateProducto(newProducto);
             return newProducto;
        }
            

        public async Task DeleteProducto(Guid Id)
        {
         await  _productoRepository.DeleteProducto(Id);
        }

        public Task<List<Producto>> GetAll()
        {
            return _productoRepository.Get();
        }

        public Task<Producto> GetById(Guid Id)
        {
           return _productoRepository.GetById(Id);
        }

        public async Task  UpdateProducto(Guid Id, Producto nuevoRegistros)
        {
         await  _productoRepository.UpdateProducto(Id, nuevoRegistros);
        }
    }
}
