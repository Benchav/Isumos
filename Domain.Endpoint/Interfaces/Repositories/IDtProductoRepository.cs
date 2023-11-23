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
        void Create(DtProducto Nproduc);

        void Update(Guid Id, DtProducto nuevosRegistro);

        void Delete(Guid Id);
    }
}
