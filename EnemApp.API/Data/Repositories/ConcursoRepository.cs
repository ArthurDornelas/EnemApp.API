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
    public class ConcursoRepository : BaseRepository<Concurso>, IConcursoRepository
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
            //var candidatosQuery = _dbContext.CandidatosConcursos.Select(c => c.Candidato).Where(;
                return candidatosQuery;
        }

        public void AddCandidatosConcurso(int id)
        {
       
            var candidatos = _dbContext.Candidatos;
            var concurso = GetById(id);

            var candidatosConcurso = GetCandidatosConcurso(id).ToList();
            var candConcursos = new List<CandidatoConcurso>();

            foreach (Candidato candidato in candidatos)
            {
                var existeCandidatoNoConcurso = candidatosConcurso.Any(x => x.Id == candidato.Id);

                if (existeCandidatoNoConcurso)
                    continue;
                else
                {
                    CandidatoConcurso candConc = new CandidatoConcurso();

                    candConc.Concurso = concurso;
                    candConc.ConcursoId = concurso.Id;

                    candConc.Candidato = candidato;
                    candConc.CandidatoId = candidato.Id;

                    candidato.CandidatosConcursos.Add(candConc);
                    concurso.CandidatosConcursos.Add(candConc);
                    candConcursos.Add(candConc);
                    
                }

            }

            _dbContext.CandidatosConcursos.UpdateRange(candConcursos);
            _dbContext.Candidatos.UpdateRange(candidatos);
            _dbContext.Concursos.Update(concurso);

            _dbContext.SaveChanges();

        }

        public Concurso GetConcursosComCandidatos(int id)
        {
         
            var concurso = _dbContext.Concursos
                .Include(p => p.CandidatosConcursos).ThenInclude(c => c.Candidato).FirstOrDefault(x => x.Id == id);

            return concurso;
        }
    }
}
