using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Services;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class CatService : ICatService
    {
        private readonly ICatRepository _catproductoRepository; 

        public CatService(ICatRepository CatProductoRepository)
        {
            _catproductoRepository = CatProductoRepository;
        }
        public Cat CreateCatProducto(Cat nuevoCatProducto)
        {
            Cat newCatProducto = new Cat()
            {
                Id = Guid.NewGuid(),
                Descripcion = nuevoCatProducto.Descripcion,
                Estado = nuevoCatProducto.Estado,
                FechaCreacion = nuevoCatProducto.FechaCreacion

            };

            _catproductoRepository.CreateCatProducto(newCatProducto);
            return newCatProducto;
        }



        public void DeleteCatProducto(Guid Id)
        {
            _catproductoRepository.DeleteCatProducto(Id);
        }



        public Task<List<Cat>> GetAll()
        {
            return _catproductoRepository.Get();
        }


        public void UpdateCatProducto(Guid Id, Cat nuevosRegistros)
        {
            _catproductoRepository.UpdateCatProducto(Id, nuevosRegistros);
        }
    }
}
