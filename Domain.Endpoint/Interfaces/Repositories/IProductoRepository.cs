using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> Get();

        Task<Producto> GetById(Guid Id);
        Task CreateProducto(Producto nuevoProducto);

        Task DeleteProducto(Guid Id);

       Task UpdateProducto(Guid Id, Producto nuevosRegistros);
    }
}
