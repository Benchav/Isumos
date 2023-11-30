using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAll();
        Task<Producto> GetById(Guid Id);
        Producto CreateProducto(Producto nuevoProducto);

        Task DeleteProducto(Guid Id);

        Task UpdateProducto(Guid Id, Producto nuevoRegistros);

    }
}