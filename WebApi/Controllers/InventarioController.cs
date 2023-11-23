using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class InventarioController : ApiController
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetInV()
        {
            List<Inventario> inventario =await _inventarioService.GetInV();

            return Ok(inventario);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(Guid Id)
        {
            Inventario Inventario = await _inventarioService.GetById(Id);
            return Ok(Inventario);
        }

        [HttpPost]
        public IHttpActionResult PostInV(Inventario Ninventario)  
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inventario newInventario = _inventarioService.CreateInV(Ninventario);

            return Created(Request.RequestUri + "/" + newInventario.Id, newInventario);
        }


        [HttpDelete]
        public IHttpActionResult DeleteInV(Guid Id)
        {
            _inventarioService.DeleteInV(Id);

            return Ok("El registro del inventario seleccionado ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateInV(Guid Id, Inventario nuevosRegistros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _inventarioService.UpdateInV(Id, nuevosRegistros);

            return Ok("El registro del inventario  seleccionado ha sido modificado");
        }
       
    }
}
