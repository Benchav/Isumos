using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IInventarioRepository
    {
        Task<List<Inventario>> GetInV();

        void CreateInV(Inventario Ninventario);

        void DeleteInV(Guid Id);

        void UpdateInV(Guid Id,  Inventario nuevosInv);
    }
}
