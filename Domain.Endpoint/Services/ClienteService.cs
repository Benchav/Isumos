﻿using Domain.Endpoint.Entities;
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



         public async Task DeleteCliente(Guid Id)
         {
            await _clienteRepository.DeleteCliente(Id);
         }


        public async Task<List<Cliente>> GetAll()
        {
            return await _clienteRepository.Get();
        }

        public async Task<Cliente> GetById(Guid Id)
        {
            return await _clienteRepository.GetById(Id);
        }

        public async Task UpdateCliente(Guid Id, Cliente nuevosRegistros)
        {
           await  _clienteRepository.UpdateCliente(Id, nuevosRegistros);
        }
    }
}