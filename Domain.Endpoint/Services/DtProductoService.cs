using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class DtProductoService : IDtProductoService
    {
        private readonly IDtProductoRepository _dtProductoRepository;

        public DtProductoService(IDtProductoRepository dtProductoRepository)
        {
            _dtProductoRepository = dtProductoRepository;
        }

        public DtProducto Create(DtProducto Nproduc)
        {
           DtProducto newDProduc = new DtProducto()
            {
                Id = Guid.NewGuid(),
                IdProducto = Guid.NewGuid(),              
                Descripcion = Nproduc.Descripcion,
                Marca = Nproduc.Marca,
                Medida = Nproduc.Medida,
                Estado = Nproduc.Estado,
            };
            _dtProductoRepository.Create(newDProduc);
            return newDProduc;
        }

        public void Delete(Guid Id)
        {
          _dtProductoRepository.Delete(Id);
        }

        public Task<List<DtProducto>> Get()
        {
          return _dtProductoRepository.Get();
        }

        public Task<DtProducto> GetById(Guid Id)
        {
           return _dtProductoRepository.GetById(Id);
        }

        public void Update(Guid Id, DtProducto nuevosRegistros)
        {
           _dtProductoRepository.Update(Id, nuevosRegistros);
        }
    }
}
