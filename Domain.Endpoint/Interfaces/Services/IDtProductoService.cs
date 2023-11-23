using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IDtProductoService
    {
        Task<List<DtProducto>> Get();

        DtProducto Create(DtProducto Nproduc);

        void Update(Guid Id, DtProducto nuevosRegistros);

        void Delete(Guid Id);
    }
}
