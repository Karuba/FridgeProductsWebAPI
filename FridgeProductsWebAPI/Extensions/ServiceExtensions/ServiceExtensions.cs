using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using FridgeProductsWebAPI.Middleware;
using Services.Abstractions;
using FridgeProducts.Domain.Interfaces.Repositories;
using FridgeProducts.Infrastructure.Data.Repositories;
using FridgeProducts.Infrastructure.Migr.MsSQL;

namespace FridgeProductsWebAPI.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureDatabaseContext(this IServiceCollection services,
            IConfiguration configuration) =>
                ConnectionExtension.ConfigureDatabaseContext(services, configuration);
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureExceptionHandlerMiddleware(this IServiceCollection services) =>
            services.AddTransient<ExceptionHandlingMiddleware>();
    }
}
