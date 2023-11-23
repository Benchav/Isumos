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
       void CreateCat(Cat nuevoCatProducto); 
       void DeleteCat(Guid Id);
       void UpdateCat(Guid Id, Cat nuevosRegistros);
       
    }
}
