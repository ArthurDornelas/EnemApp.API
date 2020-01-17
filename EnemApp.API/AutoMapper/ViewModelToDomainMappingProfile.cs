using AutoMapper;
using EnemApp.API.Models;
using EnemApp.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CandidatoViewModel, Candidato>();
            CreateMap<ConcursoViewModel, Concurso>();
        }
    }
}
