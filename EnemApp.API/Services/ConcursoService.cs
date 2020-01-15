using EnemApp.API.Interfaces.RepositoriesInterfaces;
using EnemApp.API.Interfaces.ServicesInterfaces;
using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Services
{
    public class ConcursoService : BaseService<Concurso>, IConcursoService
    {
        private readonly IConcursoRepository _concursoRepository;

        public ConcursoService(IConcursoRepository concursoRepository)
        {
            _concursoRepository = concursoRepository;
        }
        public Concurso AddConcurso<TConcursoValidator>(Concurso concurso)
        {
            _concursoRepository.Add(concurso);
            return concurso;
        }

        public void DeleteConcurso(int idConcurso)
        {
            _concursoRepository.Remove(idConcurso);
        }

        public Concurso GetConcurso(int idConcurso)
        {
            var concursoBd = _concursoRepository.GetById(idConcurso);

            return concursoBd;
        }

        public IEnumerable<Concurso> GetConcursos()
        {
            var concursos = _concursoRepository.SelectAll().ToList();

            return concursos;
        }

        public Concurso UpdateConcurso<TConcursoValidator>(Concurso concurso)
        {
            _concursoRepository.Update(concurso);
            return concurso;
        }

        public IEnumerable<Concurso> UpdateConcursos(IEnumerable<Concurso> concursos)
        {
            var concursosDb = _concursoRepository.UpdateConcursos(concursos);

            return concursosDb;
        }

        public IEnumerable<Candidato> GetCandidatosConcurso(int id)
        {
            var candidatosConcurso = _concursoRepository.GetCandidatosConcurso(id).ToList();

            return candidatosConcurso;
        }

        public void AddCandidatosConcurso(int id)
        {
            _concursoRepository.AddCandidatosConcurso(id);
        }

    }
}
