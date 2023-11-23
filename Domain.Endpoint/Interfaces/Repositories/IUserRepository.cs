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
        void CreateUser(User nuevoUser);

        void DeleteUser(Guid Id);

        void UpdateUser(Guid Id, User nuevoUs);

    }

}

