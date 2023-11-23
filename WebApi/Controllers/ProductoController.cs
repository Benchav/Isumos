using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProducto()
        {
            List<Producto> producto = await _productoService.GetAll();

            return Ok(producto);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(Guid Id)
        {
            Producto producto = await _productoService.GetById(Id);
            return Ok(producto);
        }

        [HttpPost]
        public IHttpActionResult PostProducto(Producto nuevoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Producto newProducto = _productoService.CreateProducto(nuevoProducto);

            return Created(Request.RequestUri + "/" + newProducto.Id, newProducto);
        }


        [HttpDelete]
        public IHttpActionResult DeleteProducto(Guid Id)
        {
            _productoService.DeleteProducto(Id);

            return Ok("Producto eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateProducto(Guid Id, Producto nuevosRegistros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productoService.UpdateProducto(Id, nuevosRegistros);

            return Ok("Producto modificado");
        }

    }
}
