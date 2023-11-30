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
    public class ProveedorRepository : IProveedorRepository
    {

        private readonly ISqlDbConnection _sqlDbConnection;
        private readonly ISqlCommandOperationBuilder _operationBuilder;
        public ProveedorRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
        {
            _sqlDbConnection = sqlDbConnection;
            _operationBuilder = operationBuilder;
        }

        public async Task CreateProveedor(Proveedor nuevoProveedor)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoProveedor)
               .WithOperation(SqlWriteOperation.Create)
               .BuildWritter();
           await _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }

        public async Task DeleteProveedor(Guid Id)
        {
     
            string delec = "DELETE FROM TblProveedor WHERE IdProveedor = @IdProveedor";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProveedor",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
          await  sqlCommand.ExecuteNonQueryAsync();
        }

        public async Task<List<Proveedor>> Get()
        {
            SqlCommand readCommand = _operationBuilder.Initialize<Proveedor>()
            .WithOperation(SqlReadOperation.Select)
            .BuildReader();
            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            List<Proveedor> cat = dt.AsEnumerable().Select(row =>
            new Proveedor
            {
                Id = row.Field<Guid>("IdProveedor"),
                NombreCompañia = row.Field<string>("NombreCompañia"),
                Correo = row.Field<string>("Correo"),
                Telefono = row.Field<int>("Telefono"),
                Estado = row.Field<int>("Estado"),
                FechaCreacion = row.Field<DateTime>("FechaCreacion"),
            }).ToList();

            return cat;
        }

        public async Task<Proveedor> GetById(Guid Id)
        {
            SqlCommand readCommand = _operationBuilder.Initialize<Proveedor>()
                .WithOperation(SqlReadOperation.SelectById)
                .WithId(Id)
                .BuildReader();

            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);
            if (dt.Rows.Count >0)
            {
                DataRow row = dt.Rows[0];
                Proveedor proveedor = new Proveedor
                {
                    Id = row.Field<Guid>("IdProveedor"),
                    NombreCompañia = row.Field<string>("NombreCompañia"),
                    Correo = row.Field<string>("Correo"),
                    Telefono = row.Field<int>("Telefono"),
                    Estado = row.Field<int>("Estado"),
                    FechaCreacion = row.Field<DateTime>("FechaCreacion"),
                };
                return proveedor;
            }
            return null;
        }

        public async Task UpdateProveedor(Guid Id, Proveedor nuevoProv)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoProv)
                        .WithOperation(SqlWriteOperation.Update)
                        .BuildWritter();
         await   _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }
    }
}