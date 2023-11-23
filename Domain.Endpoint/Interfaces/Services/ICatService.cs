using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface ICatService
    {
        Task<List<Cat>> GetAll();

        Cat CreateCatProducto(Cat nuevoCatProducto);

        void DeleteCatProducto(Guid Id);

        void UpdateCatProducto(Guid Id, Cat nuevoRegistros);

    }
}
