using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProveedorController : ApiController
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProveedor()
        {
            List<Proveedor> proveedor = await _proveedorService.GetAll();

            return Ok(proveedor);
        }

        [HttpPost]
        public IHttpActionResult PostProveedor(Proveedor nuevoProveedor)
        {
            Proveedor newProveedor = _proveedorService.CreateProveedor(nuevoProveedor);

            return Ok(newProveedor);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCatProveedor(Guid Id)
        {
            _proveedorService.DeleteProveedor(Id);

            return Ok("El producto seleccionado ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateProveedor(Guid Id, Proveedor nuevosRegistros)
        {
            _proveedorService.UpdateProveedor(Id, nuevosRegistros);

            return Ok("El Producto seleccinado ha sido modificado");
        }
    }
}

