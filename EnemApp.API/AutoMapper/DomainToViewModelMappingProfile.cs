using AutoMapper;
using EnemApp.API.Models;
using EnemApp.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Candidato, CandidatoViewModel>();
            CreateMap<Concurso, ConcursoViewModel>();
        }
    }
}
