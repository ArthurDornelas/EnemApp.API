using EnemApp.API.Interfaces.RepositoriesInterfaces;
using EnemApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Data.Repositories
{
    public class ConcursoRepository: BaseRepository<Concurso>, IConcursoRepository
    {
        public ConcursoRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Concurso> UpdateConcursos(IEnumerable<Concurso> concursos)
        {
            _dbContext.Concursos.UpdateRange(concursos);
            _dbContext.SaveChanges();

            return concursos;
        }

        public IEnumerable<Candidato> GetCandidatosConcurso(int id)
        {
            var candidatosQuery = _dbContext.Concursos.Where(c => c.Id == id).SelectMany(c => c.CandidatosConcursos.Select(c => c.Candidato));
            return candidatosQuery;
        }

        public void AddCandidatosConcurso(int id)
        {
            BaseRepository<Candidato> candidatoRepository = new BaseRepository<Candidato>(_dbContext);
            var candidatos = candidatoRepository.SelectAll();
            var concurso = GetById(id);
            
            
            foreach (Candidato candidato in candidatos)
            {
                CandidatoConcurso candConc = new CandidatoConcurso();

                candConc.Concurso = concurso;
                candConc.ConcursoId = concurso.Id;
                
                candConc.Candidato = candidato;
                candConc.CandidatoId = candidato.Id;

                candidato.CandidatosConcursos.Add(candConc);
                concurso.CandidatosConcursos.Add(candConc);

            }


            _dbContext.Candidatos.UpdateRange(candidatos);
            _dbContext.Concursos.Update(concurso);

            _dbContext.SaveChanges();

        }

    }
}
