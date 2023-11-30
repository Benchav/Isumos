using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> Get();
        Task<Cliente> GetById(Guid Id);
        Task CreateCliente(Cliente nuevoCliente);
        Task DeleteCliente(Guid Id);
        Task UpdateCliente(Guid Id, Cliente nuevoClie);
    }
       
}