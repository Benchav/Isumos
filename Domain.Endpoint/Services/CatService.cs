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
        public Cat CreateCat(Cat nuevoCatProducto)
        {
            Cat newCatProducto = new Cat()
            {
                Id = Guid.NewGuid(),
                Descripcion = nuevoCatProducto.Descripcion,
                Estado = nuevoCatProducto.Estado,
                FechaCreacion = nuevoCatProducto.FechaCreacion

            };

            _catproductoRepository.CreateCat(newCatProducto);
            return newCatProducto;
        }



       public async Task DeleteCat(Guid Id)
        {
         await  _catproductoRepository.DeleteCat(Id);
        }



        public Task<List<Cat>> GetAll()
        {
            return _catproductoRepository.Get();
        }

        public Task<Cat> GetById(Guid Id)
        {
            return _catproductoRepository.GetById(Id);
        }

        public async Task UpdateCat(Guid Id, Cat nuevosRegistros)
        {
          await   _catproductoRepository.UpdateCat(Id, nuevosRegistros);
        }
    }
}
