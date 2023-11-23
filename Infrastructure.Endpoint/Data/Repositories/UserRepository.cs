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
    public class UserResopitory : IUserRepository
    {
        private readonly ISqlDbConnection _sqlDbConnection;
        private readonly ISqlCommandOperationBuilder _operationBuilder;
        public UserResopitory(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
        {
            _sqlDbConnection = sqlDbConnection;
            _operationBuilder = operationBuilder;
        }

        public void CreateUser(User nuevoUser)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoUser)
               .WithOperation(SqlWriteOperation.Create)
               .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }

        public void DeleteUser(Guid Id)
        {
            string delec = "DELETE FROM TblUsuario WHERE IdUsuario = @IdUsuario";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdUsuario",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }

        public async Task<List<User>> Get()
        {
            SqlCommand readCommand = _operationBuilder.Initialize<User>()
                .WithOperation(SqlReadOperation.Select)
                .BuildReader();
            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            List<User> cat = dt.AsEnumerable().Select(row =>
            new User
            {
                Id = row.Field<Guid>("IdUsuario"),
                PrimerNombre = row.Field<string>("PrimerNombre"),
                SegundoNombre = row.Field<string>("SegundoNombre"),
                PrimerApellido = row.Field<string>("PrimerApellido"),
                SegundoApellido = row.Field<string>("SegundoApellido"),
                Correo = row.Field<string>("Correo"),
                IdRol= row.Field<Guid>("IdRol"),
                Estado = row.Field<int>("Estado"),
                Sexo = row.Field<string>("Sexo"),
                UserName = row.Field<string>("UserName"),
                Contraseña = row.Field<string>("Contraseña"),
                FechaCreacion = row.Field<DateTime>("FechaCreacion"),
            }).ToList();

            return cat;
        }

        public async Task<User> GetById(Guid Id)
        {
            SqlCommand readCommand = _operationBuilder.Initialize<User>()
             .WithOperation(SqlReadOperation.SelectById)
             .WithId(Id)
             .BuildReader();

            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);
            if (dt.Rows.Count >0)
            {
                DataRow row = dt.Rows[0];
                User user = new User
                {
                    Id = row.Field<Guid>("IdUsuario"),
                    PrimerNombre = row.Field<string>("PrimerNombre"),
                    SegundoNombre = row.Field<string>("SegundoNombre"),
                    PrimerApellido = row.Field<string>("PrimerApellido"),
                    SegundoApellido = row.Field<string>("SegundoApellido"),
                    Correo = row.Field<string>("Correo"),
                    IdRol = row.Field<Guid>("IdRol"),
                    Estado = row.Field<int>("Estado"),
                    Sexo = row.Field<string>("Sexo"),
                    UserName = row.Field<string>("UserName"),
                    Contraseña = row.Field<string>("Contraseña"),
                    FechaCreacion = row.Field<DateTime>("FechaCreacion"),
                };
                return user;
            }
            return null;
        }

        public void UpdateUser(Guid Id, User nuevoUs)
        {
            SqlCommand writeCommand = _operationBuilder.From(nuevoUs)
                        .WithOperation(SqlWriteOperation.Update)
                        .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }
    }
}