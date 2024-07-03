using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste.Application.Interfaces;
using Teste.Application.Mapping;
using Teste.Application.Services;
using Teste.Domain.Interfaces;
using Teste.Infra.Data.Context;
using Teste.Infra.Data.Repositories;

namespace Teste.Infra.Ioc
{
    public static class DependencyInjectionApi
    {
         public static IServiceCollection AddInFrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                ops => ops.UseNpgsql(
                    configuration.GetConnectionString("teste"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                )
            );

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IMovieServices, MovieServices>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var handles = AppDomain.CurrentDomain.Load("Teste.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handles));

            return services;
        }
    }
}