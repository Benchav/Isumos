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
        void CreateCliente(Cliente nuevoCliente);
        void DeleteCliente(Guid Id);
        void UpdateCliente(Guid Id, Cliente nuevoClie);
    }
       
}