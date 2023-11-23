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
    public class DtProductoRepository : IDtProductoRepository
    {
        private readonly ISqlDbConnection _sqlDbConnection;
        private readonly ISqlCommandOperationBuilder _operationBuilder;

        public DtProductoRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
        {
            _sqlDbConnection = sqlDbConnection;
            _operationBuilder = operationBuilder;
        }

        public void Create(DtProducto Nproduc)
        {
            SqlCommand writeCommand = _operationBuilder.From(Nproduc)
               .WithOperation(SqlWriteOperation.Create)
               .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }

        public void Delete(Guid Id)
        {
            string delete = "DELETE FROM TblDetalleProducto WHERE IdProductoDetalle = @IdProductoDetalle";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delete);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProductoDetalle",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }

        public async Task<List<DtProducto>> Get()
        {
            SqlCommand readCommand = _operationBuilder.Initialize<DtProducto>()
             .WithOperation(SqlReadOperation.Select)
             .BuildReader();
            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            List<DtProducto> cat = dt.AsEnumerable().Select(row =>
            new DtProducto
            {
              Id = row.Field<Guid>("IdProductoDetalle"),
              IdProducto = row.Field<Guid>("IdProducto"),
              Descripcion = row.Field<string>("Descripcion"),
              Marca = row.Field<string>("Marca"),
              Medida = row.Field<string>("Medida"),
              Estado = row.Field<int>("Estado"),

            }).ToList();
            return cat;
        }

        public void Update(Guid Id, DtProducto nuevosRegistro)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevosRegistro)
              .WithOperation(SqlWriteOperation.Update)
              .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }
    }
}
