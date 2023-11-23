using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public IHttpActionResult PostUser(User nuevoUser)
        {
            User newUser = _userService.CreateUser(nuevoUser);

            return Ok(newUser);
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
            _userService.UpdateUser(Id, nuevosRegistros);

            return Ok("El Usuario seleccinado ha sido modificado");
        }

    }
}