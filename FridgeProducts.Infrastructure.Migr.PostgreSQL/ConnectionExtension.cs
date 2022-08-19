using FridgeProducts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FridgeProducts.Infrastructure.Migr.PostgreSQL
{
    public static class ConnectionExtension
    {
        public static void ConfigureDatabaseContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"), b =>
                        b.MigrationsAssembly("FridgeProducts.Infrastructure.Migr.PostgreSQL")));
    }
}
