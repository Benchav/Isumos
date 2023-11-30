using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface ICatService
    {
        Task<List<Cat>> GetAll();
        Task<Cat> GetById(Guid Id);
        Cat CreateCat(Cat nuevoCatProducto);

        Task DeleteCat(Guid Id);

       Task UpdateCat(Guid Id, Cat nuevoRegistros);

    }
}
