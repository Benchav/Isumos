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
    public class InventarioRepository : IInventarioRepository
    {
        private readonly ISqlDbConnection _sqlDbConnection;
        private readonly ISqlCommandOperationBuilder _operationBuilder;

        public InventarioRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
        {
            _sqlDbConnection = sqlDbConnection;
            _operationBuilder = operationBuilder;
        }

        public void CreateInV(Inventario Ninventario)
        {
           SqlCommand WriteCommand = _operationBuilder.From(Ninventario)
                .WithOperation(Builders.SqlWriteOperation.Create)
                .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommand(WriteCommand);
        }

        public void DeleteInV(Guid Id)
        {
            string delec ="DELETE FROM TblInventario WHERE IdInventario= @IdInventario";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "idInventario",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }

        public async Task<Inventario> GetById(Guid Id)
        {
            SqlCommand readCommand = _operationBuilder.Initialize<Inventario>()
              .WithOperation(SqlReadOperation.SelectById)
              .WithId(Id)
              .BuildReader();

            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);
            if (dt.Rows.Count >0)
            {
                DataRow row = dt.Rows[0];
                Inventario inventario = new Inventario
                {
                    Id = row.Field<Guid>("IdInventario"),
                    IdProductoDetalle = row.Field<Guid>("IdProductoDetalle"),
                    Proveedor = row.Field<string>("Proveedor"),
                    Existencia = row.Field<int>("Existencia"),
                    Lote = row.Field<string>("Lote"),
                    PrecioVenta = row.Field<decimal>("PrecioVenta"),
                    PrecioCompra = row.Field<decimal>("PrecioCompra"),
                    FechaCompra = row.Field<DateTime>("FechaCompra"),
                    FechaVencimiento = row.Field<DateTime>("FechaVencimiento")
                };
                return inventario;
            }
            return null;
        }

        public async Task<List<Inventario>> GetInV()
        {
            SqlCommand readCommand = _operationBuilder.Initialize<Inventario>()
              .WithOperation(SqlReadOperation.Select)
              .BuildReader();
            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            List<Inventario> cat= dt.AsEnumerable().Select(row =>
            new Inventario
            {
             Id =row.Field<Guid>("IdInventario"),
             IdProductoDetalle=row.Field<Guid>("IdProductoDetalle"),
             Proveedor=row.Field<string>("Proveedor"),
             Existencia=row.Field<int>("Existencia"),
             Lote=row.Field<string>("Lote"),
             PrecioVenta=row.Field<decimal>("PrecioVenta"),
             PrecioCompra=row.Field<decimal>("PrecioCompra"),
             FechaCompra=row.Field<DateTime>("FechaCompra"),
             FechaVencimiento=row.Field<DateTime>("FechaVencimiento")
            }).ToList();

            return cat;

        }

        public void UpdateInV(Guid Id, Inventario nuevosInv)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevosInv)
              .WithOperation(SqlWriteOperation.Update)
              .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }
    }
}
