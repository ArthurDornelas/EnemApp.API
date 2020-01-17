using AutoMapper;
using EnemApp.API.Interfaces.RepositoriesInterfaces;
using EnemApp.API.Interfaces.ServicesInterfaces;
using EnemApp.API.Models;
using EnemApp.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Services
{
    public class ConcursoService : BaseService<Concurso>, IConcursoService
    {
        private readonly IConcursoRepository _concursoRepository;
        private readonly IMapper _mapper;

        public ConcursoService(IConcursoRepository concursoRepository, IMapper mapper)
        {
            _concursoRepository = concursoRepository;
            _mapper = mapper;
        }
        public ConcursoViewModel AddConcurso(ConcursoViewModel concursoVM)
        {
            var concurso = _mapper.Map<Concurso>(concursoVM);
            concurso = _concursoRepository.Add(concurso);

            return _mapper.Map<ConcursoViewModel>(concurso);
        }

        public void DeleteConcurso(int idConcurso)
        {
            _concursoRepository.Remove(idConcurso);
        }

        public ConcursoViewModel GetConcurso(int idConcurso)
        {
            var concurso = _concursoRepository.GetConcursosComCandidatos(idConcurso);
            var concursoVM = _mapper.Map<ConcursoViewModel>(concurso);
           
            return concursoVM;
        }

        public IEnumerable<ConcursoViewModel> GetConcursos()
        {
            var concursos = _concursoRepository.SelectAll().ToList();
            var concursosVM = _mapper.Map<IEnumerable<ConcursoViewModel>>(concursos);

            return concursosVM;
        }

        public ConcursoViewModel UpdateConcurso(ConcursoViewModel concursoVM)
        {
            var concurso = _mapper.Map<Concurso>(concursoVM);
            var concursoBd = _concursoRepository.Update(concurso);

            return _mapper.Map<ConcursoViewModel>(concursoBd);
        }

        public IEnumerable<ConcursoViewModel> UpdateConcursos(IEnumerable<ConcursoViewModel> concursosVW)
        {
            var concursos = _mapper.Map<IEnumerable<Concurso>>(concursosVW);
            var concursosDb = _concursoRepository.UpdateConcursos(concursos);

            return _mapper.Map<IEnumerable<ConcursoViewModel>>(concursosDb);
        }

        public IEnumerable<CandidatoViewModel> GetCandidatosConcurso(int id)
        {
            var candidatosConcurso = _concursoRepository.GetCandidatosConcurso(id).ToList();

            return _mapper.Map<IEnumerable<CandidatoViewModel>>(candidatosConcurso);
        }

        public void AddCandidatosConcurso(int id)
        {
            _concursoRepository.AddCandidatosConcurso(id);
        }

        public ConcursoViewModel GetConcursoComCandidatos(int idConcurso)
        {
            var concursoBd = _concursoRepository.GetConcursosComCandidatos(idConcurso);

            return _mapper.Map<ConcursoViewModel>(concursoBd);
        }
    }
}
