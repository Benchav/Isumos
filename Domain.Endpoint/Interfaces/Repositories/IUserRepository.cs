using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> Get();

        Task<User> GetById(Guid Id);
        Task CreateUser(User nuevoUser);

        Task DeleteUser(Guid Id);

        Task UpdateUser(Guid Id, User nuevoUs);

    }

}

