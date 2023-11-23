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
        void CreateProducto(Producto nuevoProducto);

        void DeleteProducto(Guid Id);

        void UpdateProducto(Guid Id, Producto nuevosRegistros);
    }
}
