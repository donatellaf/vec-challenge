using Project.Domain.CustomEntitites;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;
using Project.Domain.Services;
using Project.Infra.Data.DbContexts;
using Project.Infra.Data.Interfaces;
using Project.Infra.Data.Repositories;
using Project.Infra.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Project.Infra.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ProjectChallenge"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IVehiculoService, VehiculoService>();
            services.AddTransient<IMarcaService, MarcaService>();
            services.AddTransient<ITipoVehiculoService, TipoVehiculoService>();
            services.AddTransient<ITransmisionService, TransmisionService>();
            services.AddTransient<ICombustibleService, CombustibleService>();
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Project API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
