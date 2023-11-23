using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUser()
        {
            List<User> user = await _userService.GetAll();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(Guid Id)
        {
            User User = await _userService.GetById(Id);
            return Ok(User);
        }

        [HttpPost]
        public IHttpActionResult PostUser(User nuevoUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User newUser = _userService.CreateUser(nuevoUser);

            return Created(Request.RequestUri + "/" + newUser.Id, newUser);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(Guid Id)
        {
            _userService.DeleteUser(Id);

            return Ok("El Usuario seleccionado ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(Guid Id, User nuevosRegistros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            _userService.UpdateUser(Id, nuevosRegistros);
            return Ok("El Usuario seleccinado ha sido modificado");


        }

    }
}