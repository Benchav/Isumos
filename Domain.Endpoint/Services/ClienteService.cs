using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository ClienteRepository)
        {
            _clienteRepository = ClienteRepository;
        }

     
        

        public Cliente CreateCliente(Cliente nuevoCliente)
        {
            Cliente newCliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                PrimerNombre = nuevoCliente.PrimerNombre,
                SegundoNombre = nuevoCliente.SegundoNombre,
                PrimerApellido = nuevoCliente.PrimerApellido,
                SegundoApellido = nuevoCliente.SegundoApellido,
                Correo = nuevoCliente.Correo,
                Telefono = nuevoCliente.Telefono,
                Estado = nuevoCliente.Estado,
                FechaCreacion = nuevoCliente.FechaCreacion

            };

            _clienteRepository.CreateCliente(newCliente);
            return newCliente;
        }



         public void DeleteCliente(Guid Id)
         {
             _clienteRepository.DeleteCliente(Id);
         }


        public async Task<List<Cliente>> GetAll()
        {
            return await _clienteRepository.Get();
        }

  


        public void UpdateCliente(Guid Id, Cliente nuevosRegistros)
        {
            _clienteRepository.UpdateCliente(Id, nuevosRegistros);
        }
    }
}