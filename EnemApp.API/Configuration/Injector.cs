using EnemApp.API.Data;
using EnemApp.API.Data.Repositories;
using EnemApp.API.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Interfaces.RepositoriesInterfaces;
using EnemApp.API.Interfaces.ServicesInterfaces;
using EnemApp.API.Models;
using EnemApp.API.Validators;
using FluentValidation;
using EnemApp.API.ViewModels;

namespace EnemApp.API.Configuration
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();

            services.AddScoped<ICandidatoRepository, CandidatoRepository>();

            services.AddScoped<ICandidatoService, CandidatoService>();

            //services.AddTransient<IValidator<Candidato>, CandidatoValidator>();

            services.AddTransient<IValidator<CandidatoViewModel>, CandidatoValidator>();

            services.AddTransient<IValidator<ConcursoViewModel>, ConcursoValidator>();

            services.AddScoped<IConcursoRepository, ConcursoRepository>();

            services.AddScoped<IConcursoService, ConcursoService>();

        }
    }
}
