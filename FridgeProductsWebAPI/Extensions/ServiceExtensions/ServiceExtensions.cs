using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using FridgeProductsWebAPI.Middleware;
using Services.Abstractions;
using FridgeProducts.Infrastructure.Data;
using FridgeProducts.Domain.Interfaces.Repositories;
using FridgeProducts.Infrastructure.Data.Repositories;

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
        public static void ConfigureMsSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("MsSQLConnection"), b =>
                        b.MigrationsAssembly("FridgeProducts.Infrastructure.Migration")));
        public static void ConfigurePostgreSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"), b =>
                        b.MigrationsAssembly("FridgeProducts.Infrastructure.Migr.PostgreSQL")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureExceptionHandlerMiddleware(this IServiceCollection services) =>
            services.AddTransient<ExceptionHandlingMiddleware>();
    }
}
