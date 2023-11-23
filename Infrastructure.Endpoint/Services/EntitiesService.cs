using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Builders;
using Infrastructure.Endpoint.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Endpoint.Services
{
    public class EntitiesService : IEntitiesService

    {
        private Dictionary<Type, SqlEntitySettings> entities = new Dictionary<Type, SqlEntitySettings>();
 

        public EntitiesService()
        {
            BuildEntities();
        }

        public SqlEntitySettings GetSettings<TEntity>() where TEntity : BaseEntity
        {
            if (!entities.ContainsKey(typeof(TEntity))) throw new ArgumentOutOfRangeException(nameof(TEntity), "La entidad no fue encontrada");

            return entities[typeof(TEntity)];
        }

        private void BuildEntities()
        {
          
          
            SqlEntitySettings CatProductoSettings = GetCatProductoSettings();
            SqlEntitySettings ClienteSettings = GetClienteSettings();
            SqlEntitySettings ProductoSettings = GetProductoSettings();
            SqlEntitySettings ProveedorSettings = GetProveedorSettings();
            SqlEntitySettings UserSettings = GetUserSettings();
            SqlEntitySettings DtProductoSettings = GetDtProductoSettings();
            SqlEntitySettings InventarioSettings = GetInventario();
           
           
            entities.Add(typeof(Cat), CatProductoSettings);
            entities.Add(typeof(Cliente), ClienteSettings);
            entities.Add(typeof(Producto), ProductoSettings);
            entities.Add(typeof(Proveedor), ProveedorSettings);
            entities.Add(typeof(User), UserSettings);
            entities.Add(typeof(DtProducto), DtProductoSettings);
            entities.Add(typeof (Inventario), InventarioSettings);

 
        }

      
            
        //ENTIDAD INVENTARIO
        private SqlEntitySettings GetInventario()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "IdInventario", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "IdProductoDetalle", DomainName = "IdProductoDetalle", SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "Proveedor", DomainName = "Proveedor", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Existencia", DomainName = "Existencia", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "Lote", DomainName = "Lote", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "PrecioVenta", DomainName = "PrecioVenta", SqlDbType = SqlDbType.Decimal },
                new SqlColumnSettings() { Name = "PrecioCompra", DomainName = "PrecioCompra", SqlDbType = SqlDbType.Decimal },
                new SqlColumnSettings() { Name = "FechaCompra", DomainName = "FechaCompra", SqlDbType = SqlDbType.DateTime },
                new SqlColumnSettings() { Name = "FechaVencimiento", DomainName = "FechaVencimiento", SqlDbType = SqlDbType.DateTime },
            };

            return new SqlEntitySettings()
            {
                TableName = "TblInventario",
                Columns = columns
            };
        }


        //ENTIDAD DETALLEPRODUCTO
        private SqlEntitySettings GetDtProductoSettings()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "IdProductoDetalle", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "IdProducto", DomainName = "IdProducto", SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "Descripcion", DomainName = "Descripcion", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Marca", DomainName = "Marca", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Medida", DomainName = "Medida", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Estado", DomainName = "Estado", SqlDbType = SqlDbType.Int },
            };

            return new SqlEntitySettings()
            {
                TableName = "TblDetalleProducto",
                Columns = columns
            };
        }


        //ENTIDAD CATPRODUCTO
        private SqlEntitySettings GetCatProductoSettings()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "IdCategoria", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "Descripcion", DomainName = "Descripcion", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Estado", DomainName = "Estado", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "FechaCreacion", DomainName = "FechaCreacion", SqlDbType = SqlDbType.DateTime }
            };

            return new SqlEntitySettings()
            {
                TableName = "TblCategoria",
                Columns = columns
            };
        }

        // ENTIDAD PROVEEDOR
        private SqlEntitySettings GetProveedorSettings()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "IdProveedor", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "NombreCompañia", DomainName = "NombreCompañia", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Correo", DomainName = "Correo", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Telefono", DomainName = "Telefono", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "Estado", DomainName = "Estado", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "FechaCreacion", DomainName = "FechaCreacion", SqlDbType = SqlDbType.DateTime }
            };

            return new SqlEntitySettings()
            {
                TableName = "TblProveedor",
                Columns = columns
            };
        }

        // ENTIDAD CLIENTE
        private SqlEntitySettings GetClienteSettings()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "IdCliente", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "PrimerNombre", DomainName = "PrimerNombre", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "SegundoNombre", DomainName = "SegundoNombre", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "PrimerApellido", DomainName = "PrimerApellido", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "SegundoApellido", DomainName = "SegundoApellido", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Correo", DomainName = "Correo", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Telefono", DomainName = "Telefono", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Estado", DomainName = "Estado", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "FechaCreacion", DomainName = "FechaCreacion", SqlDbType = SqlDbType.DateTime }
            };

            return new SqlEntitySettings()
            {
                TableName = "TblCliente",
                Columns = columns
            };
        }


        // ENTIDAD PRODUCTO
        private SqlEntitySettings GetProductoSettings()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "IdProducto", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "NombreProducto", DomainName = "NombreProducto", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Descripcion", DomainName = "Descripcion", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "IdCategoria", DomainName = "IdCategoria", SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "PrecioCompra", DomainName = "Preciocompra", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "PrecioVenta", DomainName = "Precioventa", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "Estado", DomainName = "Estado", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "FechaCompra", DomainName = "FechaCompra", SqlDbType = SqlDbType.DateTime },
                new SqlColumnSettings() { Name = "FechaVencimiento", DomainName = "FechaVencimiento", SqlDbType = SqlDbType.DateTime }
            };

            return new SqlEntitySettings()
            {
                TableName = "TblProducto",
                Columns = columns
            };
        }


        // ENTIDAD USER
        private SqlEntitySettings GetUserSettings()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "IdUsuario", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "PrimerNombre", DomainName = "PrimerNombre", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "SegundoNombre", DomainName = "SegundoNombre", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "PrimerApellido", DomainName = "PrimerApellido", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "SegundoApellido", DomainName = "SegundoApellido", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Correo", DomainName = "Correo", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "IdRol", DomainName = "IdRol", SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "Estado", DomainName = "Estado", SqlDbType = SqlDbType.Int },
                new SqlColumnSettings() { Name = "Sexo", DomainName = "Sexo", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Username", DomainName = "UserName", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "Contraseña", DomainName = "Contraseña", SqlDbType = SqlDbType.VarChar },
                new SqlColumnSettings() { Name = "FechaCreacion", DomainName = "FechaCreacion", SqlDbType = SqlDbType.DateTime }
            };

            return new SqlEntitySettings()
            {
                TableName = "TblUsuario",
                Columns = columns
            };

        }
    }
}
