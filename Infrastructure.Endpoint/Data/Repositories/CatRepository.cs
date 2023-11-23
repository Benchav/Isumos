using Domain.Endpoint.Entities;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.Endpoint.Builders;
using Infrastructure.Endpoint.Interfaces;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class CatRepository : ICatRepository
    {
        private readonly ISqlDbConnection _sqlDbConnection;
        private readonly ISqlCommandOperationBuilder _operationBuilder;

        public CatRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
        {
            _sqlDbConnection = sqlDbConnection;
            _operationBuilder = operationBuilder;

        }

       public void CreateCatProducto(Cat nuevoCatProducto)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoCatProducto)
               .WithOperation(SqlWriteOperation.Create)
               .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }

        public void DeleteCatProducto(Guid Id)
        {
            //Aqui haces una consulta donde comparas los ID
            string delec = "DELETE FROM TblCategoria WHERE IdCategoria = @IdCategoria";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCategoria",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }


        public async Task<List<Cat>> Get()
        {
            SqlCommand readCommand = _operationBuilder.Initialize<Cat>()
              .WithOperation(SqlReadOperation.Select)
              .BuildReader();
            DataTable dt =  await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            List<Cat> cat = dt.AsEnumerable().Select(row =>
            new Cat
            {
                Id = row.Field<Guid>("IdCategoria"),
                Descripcion = row.Field<string>("Descripcion"),
                Estado = row.Field<int>("Estado"),
                FechaCreacion = row.Field<DateTime>("FechaCreacion"),
            }).ToList();

            return cat;
          
        }

      
        public void UpdateCatProducto(Guid Id, Cat nuevoCatProducto)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoCatProducto)
            .WithOperation(SqlWriteOperation.Update)
            .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }


    }
}