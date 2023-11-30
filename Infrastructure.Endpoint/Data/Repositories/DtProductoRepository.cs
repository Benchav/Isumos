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

        public async Task Create(DtProducto Nproduc)
        {
            SqlCommand writeCommand = _operationBuilder.From(Nproduc)
               .WithOperation(SqlWriteOperation.Create)
               .BuildWritter();
          await   _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }

        public async Task Delete(Guid Id)
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
          await  sqlCommand.ExecuteNonQueryAsync();
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

        public async Task<DtProducto> GetById(Guid Id)
        {
            SqlCommand readCommand = _operationBuilder.Initialize<DtProducto>()
             .WithOperation(SqlReadOperation.SelectById)
             .WithId(Id)
             .BuildReader();

            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);
            if (dt.Rows.Count >0)
            {
                DataRow row = dt.Rows[0];
                DtProducto dtProducto = new DtProducto
                {
                    Id = row.Field<Guid>("IdProductoDetalle"),
                    IdProducto = row.Field<Guid>("IdProducto"),
                    Descripcion = row.Field<string>("Descripcion"),
                    Marca = row.Field<string>("Marca"),
                    Medida = row.Field<string>("Medida"),
                    Estado = row.Field<int>("Estado"),
                };
                return dtProducto;
            }
            return null;
        }

        public async Task Update(Guid Id, DtProducto nuevosRegistro)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevosRegistro)
              .WithOperation(SqlWriteOperation.Update)
              .BuildWritter();
          await  _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }
    }
}
