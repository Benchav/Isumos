using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IInventarioRepository
    {
        Task<List<Inventario>> GetInV();
        Task<Inventario> GetById(Guid Id);
        Task CreateInV(Inventario Ninventario);

        Task DeleteInV(Guid Id);

        Task UpdateInV(Guid Id,  Inventario nuevosInv);
    }
}
