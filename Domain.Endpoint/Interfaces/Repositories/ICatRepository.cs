using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface ICatRepository
    {
       Task<List<Cat>> Get();
       void CreateCatProducto(Cat nuevoCatProducto); 
       void DeleteCatProducto(Guid Id);
       void UpdateCatProducto(Guid Id, Cat nuevosRegistros);
       
    }
}
