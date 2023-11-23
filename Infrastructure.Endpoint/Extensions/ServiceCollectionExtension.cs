using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Builders;
using Infrastructure.Endpoint.Data;
using Infrastructure.Endpoint.Data.Repositories;
using Infrastructure.Endpoint.Interfaces;
using Infrastructure.Endpoint.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Endpoint.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
          
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IUserRepository, UserResopitory>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ISqlCommandOperationBuilder, SqlCommandOperationBuilder>();
            services.AddScoped<IEntitiesService,EntitiesService>();
            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IDtProductoRepository, DtProductoRepository>();
            services.AddScoped<IInventarioRepository, InventarioRepository>();
            services.AddSingleton<ISqlDbConnection>(SqlDbConnection.GetInstance());  
            return services;
        }
    }
}
