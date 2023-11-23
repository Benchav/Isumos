using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAll();

        Producto CreateProducto(Producto nuevoProducto);

        void DeleteProducto(Guid Id);

        void UpdateProducto(Guid Id, Producto nuevoRegistros);

    }
}