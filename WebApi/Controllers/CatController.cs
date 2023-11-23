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
        private readonly ICatService _catService;

        public CatController(ICatService catproductoService)
        {
            _catService = catproductoService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCat()
        {
         
                List<Cat> cat = await _catService.GetAll();

                return Ok(cat); 
         
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(Guid Id)
        {
            Cat Cat = await _catService.GetById(Id);
            return Ok(Cat);
        }

        [HttpPost]
        public IHttpActionResult PostCat(Cat nuevoCatProducto)
        {
         //verifica si el cuerpo de la solicitud es valido
            if (!ModelState.IsValid)
            {
             //devuelve un codigo 400 "Bad Request" con los errores en el cuerpo que ingresamos
                return BadRequest(ModelState);
            }

            Cat newCatProducto = _catService.CreateCat(nuevoCatProducto);

            return Created(Request.RequestUri + "/" + newCatProducto.Id, newCatProducto);
            // Devuelve un código de estado 201 (Created) 
        }



        [HttpDelete]
        public IHttpActionResult DeleteCat(Guid Id)
        {
                _catService.DeleteCat(Id);

                return Ok("La categoria de producto seleccionado ha sido eliminado");
        }


        [HttpPut]
        public IHttpActionResult UpdateCat(Guid Id, Cat nuevosRegistros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _catService.UpdateCat(Id, nuevosRegistros);

                return Ok("La categoria de producto seleccionado ha sido modificado");
           
        }
    }
}
             
        
            
    
