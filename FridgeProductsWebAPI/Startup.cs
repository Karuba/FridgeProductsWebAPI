using FridgeProductsWebAPI.Extensions.ServiceExtensions;
using FridgeProductsWebAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection.Metadata;
using FridgeProducts.Contracts.Dto.Mapping;
using FridgeProducts.Infrastructure.Migr.MsSQL;

namespace FridgeProductsWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(AssemblyReference).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FridgeProductsWebAPI", Version = "v1" });
            });


            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureServiceManager();

            ServiceExtensions.ConfigureDatabaseContext(services, Configuration);
            services.ConfigureRepositoryManager();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.ConfigureExceptionHandlerMiddleware();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FridgeProductsWebAPI v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
