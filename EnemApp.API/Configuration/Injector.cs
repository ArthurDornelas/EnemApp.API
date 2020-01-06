using EnemApp.API.Data;
using EnemApp.API.Data.Repositories;
using EnemApp.API.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Configuration
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();

            services.AddScoped<ICandidatoRepository, CandidatoRepository>();

            services.AddScoped<ICandidatoService, CandidatoService>();
        }
    }
}
