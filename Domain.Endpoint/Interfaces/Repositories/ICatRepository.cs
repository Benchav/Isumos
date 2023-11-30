using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface ICatRepository
    {
       Task<List<Cat>> Get();
       Task<Cat> GetById(Guid Id);
       Task CreateCat(Cat nuevoCatProducto);
        // void DeleteCat(Guid Id);
        Task DeleteCat(Guid Id);
        Task UpdateCat(Guid Id, Cat nuevosRegistros);
       
    }
}
