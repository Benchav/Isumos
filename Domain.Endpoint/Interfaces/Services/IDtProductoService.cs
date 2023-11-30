using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IDtProductoService
    {
        Task<List<DtProducto>> Get();
        Task<DtProducto> GetById(Guid Id);
        DtProducto Create(DtProducto Nproduc);

        Task Update(Guid Id, DtProducto nuevosRegistros);

        Task Delete(Guid Id);
    }
}
