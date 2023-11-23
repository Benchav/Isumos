using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CatController : ApiController
    {
        private readonly ICatService _catproductoService;

        public CatController(ICatService catproductoService)
        {
            _catproductoService = catproductoService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCatProducto()
        {
         
                List<Cat> catproducto = await _catproductoService.GetAll();

                return Ok(catproducto); 
         
        }

        [HttpPost]
        public IHttpActionResult PostCatProducto(Cat nuevoCatProducto)
        {
                Cat newCatProducto = _catproductoService.CreateCatProducto(nuevoCatProducto);

                return Ok(newCatProducto);
        }



        [HttpDelete]
        public IHttpActionResult DeleteCatProducto(Guid Id)
        {
                _catproductoService.DeleteCatProducto(Id);

                return Ok("La categoria de producto seleccionado ha sido eliminado");
        }


        [HttpPut]
        public IHttpActionResult UpdateCatProducto(Guid Id, Cat nuevosRegistros)
        {
         

                _catproductoService.UpdateCatProducto(Id, nuevosRegistros);

                return Ok("La categoria de producto seleccionado ha sido modificado");
           
        }
    }
}
             
        
            
    
