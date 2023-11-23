using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IInventarioService
    {
        Task<List<Inventario>> GetInV();

        Inventario CreateInV(Inventario Ninventario);

        void DeleteInV(Guid Id);

        void UpdateInV(Guid Id, Inventario nuevosRegistros);
    }
}
