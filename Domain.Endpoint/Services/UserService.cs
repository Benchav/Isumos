using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
   

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User nuevoUser)
        {
            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                PrimerNombre = nuevoUser.PrimerNombre,
                SegundoNombre = nuevoUser.SegundoNombre,
                PrimerApellido = nuevoUser.PrimerApellido,
                SegundoApellido = nuevoUser.SegundoApellido,
                Correo = nuevoUser.Correo,
                IdRol = Guid.NewGuid(),
                Estado = nuevoUser.Estado,
                Sexo = nuevoUser.Sexo,
                UserName = nuevoUser.UserName,
                Contraseña = nuevoUser.Contraseña,
                FechaCreacion = nuevoUser.FechaCreacion

            };

            _userRepository.CreateUser(newUser);
            return newUser;
        }

        public async Task DeleteUser(Guid Id)
        {
          await  _userRepository.DeleteUser(Id);
        }

        public Task<List<User>> GetAll()
        {
            return _userRepository.Get();
        }

        public Task<User> GetById(Guid Id)
        {
            return _userRepository.GetById(Id);
        }

        public async Task UpdateUser(Guid Id, User nuevoRegistros)
        {
          await  _userRepository.UpdateUser(Id, nuevoRegistros);
        }
    }
}

 