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

        public void CreateProveedor(Proveedor nuevoProveedor)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoProveedor)
               .WithOperation(SqlWriteOperation.Create)
               .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }

        public void DeleteProveedor(Guid Id)
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
            sqlCommand.ExecuteNonQuery();
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

        public void UpdateProveedor(Guid Id, Proveedor nuevoProv)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoProv)
                        .WithOperation(SqlWriteOperation.Update)
                        .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }
    }
}