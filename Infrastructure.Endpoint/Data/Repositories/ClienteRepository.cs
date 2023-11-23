using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Builders;
using Infrastructure.Endpoint.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
      
    {
        private readonly ISqlDbConnection _sqlDbConnection;
        private readonly ISqlCommandOperationBuilder _operationBuilder;



        public ClienteRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
        {
            _sqlDbConnection = sqlDbConnection;
            _operationBuilder = operationBuilder;
        }

     

        public void CreateCliente(Cliente nuevoCliente)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoCliente)
                .WithOperation(SqlWriteOperation.Create)
                .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);


        }


        public void DeleteCliente(Guid Id)
        {

            string delete = "DELETE FROM TblCliente WHERE IdCliente = @IdCliente";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delete);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCliente",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }
   
     

        public async Task<List<Cliente>> Get()
        {
            SqlCommand readCommand = _operationBuilder.Initialize<Cliente>()
              .WithOperation(SqlReadOperation.Select)
              .BuildReader();
            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            List<Cliente> cat = dt.AsEnumerable().Select(row =>
            new Cliente
            {
                Id = row.Field<Guid>("IdCliente"),
                PrimerNombre = row.Field<string>("PrimerNombre"),
                SegundoNombre = row.Field<string>("SegundoNombre"),
                PrimerApellido = row.Field<string>("PrimerApellido"),
                SegundoApellido = row.Field<string>("SegundoApellido"),
                Correo = row.Field<string>("Correo"),
                Telefono = row.Field<string>("Telefono"),
                Estado = row.Field<int>("Estado"),
                FechaCreacion = row.Field<DateTime>("FechaCreacion"),
            }).ToList();

            return cat;
        }


       /* public  async Task<Cliente> GetById(Guid Id)
        {         
            SqlCommand readCommand = _operationBuilder.Initialize<Cliente>()
                  .WithOperation(SqlReadOperation.SelectById)
                  .WithId(Id)
                  .BuildReader();
           return await  _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            
        }*/


        public void UpdateCliente(Guid Id, Cliente nuevoClie)
        {

            SqlCommand writeCommand = _operationBuilder.From(nuevoClie)
               .WithOperation(SqlWriteOperation.Update)
               .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }
    }
}