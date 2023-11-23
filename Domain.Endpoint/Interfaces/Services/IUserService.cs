using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid Id);
        User CreateUser(User nuevoCatUser);

        void DeleteUser(Guid Id);

        void UpdateUser(Guid Id, User nuevoRegistros);
    }
}
