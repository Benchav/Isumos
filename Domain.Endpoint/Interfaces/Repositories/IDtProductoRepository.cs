using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IDtProductoRepository
    {
        Task<List<DtProducto>> Get();

        Task<DtProducto> GetById(Guid Id);
        Task Create(DtProducto Nproduc);

        Task Update(Guid Id, DtProducto nuevosRegistro);

        Task Delete(Guid Id);
    }
}
