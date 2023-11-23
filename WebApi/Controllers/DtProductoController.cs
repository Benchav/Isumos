using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class DtProductoController : ApiController
    {
        private readonly IDtProductoService _dtproductoService;

        public DtProductoController(IDtProductoService dtproductoService)
        {
            _dtproductoService = dtproductoService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<DtProducto> dtproducto = await _dtproductoService.Get();

            return Ok(dtproducto);
        }


        [HttpPost]
        public IHttpActionResult Post(DtProducto Nproduc)
        {
            DtProducto newDtProduc = _dtproductoService.Create(Nproduc);

            return Ok(newDtProduc);
        }


        [HttpDelete]
        public IHttpActionResult Delete(Guid Id)
        {
            _dtproductoService.Delete(Id);

            return Ok("Detalle de Producto eliminado");
        }

        [HttpPut]
        public IHttpActionResult Update(Guid Id, DtProducto nuevosRegistros)
        {
            _dtproductoService.Update(Id, nuevosRegistros);

            return Ok("Detalle de Producto modificado");
        }

    }
}
