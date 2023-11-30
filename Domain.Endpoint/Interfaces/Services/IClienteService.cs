using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAll();

        Task<Cliente> GetById(Guid Id);
        Cliente CreateCliente(Cliente nuevoCliente);
        Task DeleteCliente(Guid Id);
        Task UpdateCliente(Guid Id, Cliente nuevoRegistros);
    }
}