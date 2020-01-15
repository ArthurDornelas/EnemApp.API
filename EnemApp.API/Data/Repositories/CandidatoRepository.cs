using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Interfaces.RepositoriesInterfaces;

namespace EnemApp.API.Data.Repositories
{
    public class CandidatoRepository : BaseRepository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Candidato> UpdateCandidatos(IEnumerable<Candidato> candidatos)
        {
            _dbContext.Candidatos.UpdateRange(candidatos);
            _dbContext.SaveChanges();

            return candidatos;
        }

        public IEnumerable<Concurso> GetConcursosCandidato(int id)
        {
            var concursosQuery = _dbContext.Candidatos.Where(c => c.Id == id).SelectMany(c => c.CandidatosConcursos.Select(c => c.Concurso)).ToList();
            return concursosQuery;
        }
    }
}
