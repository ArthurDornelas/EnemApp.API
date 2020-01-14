using EnemApp.API.Interfaces.RepositoriesInterfaces;
using EnemApp.API.Models;
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
            var candidatosQuery = _dbContext.CandidatosConcursos.Where(c => c.ConcursoId == id).Select(c => c.Candidato).ToList();
            return candidatosQuery;                                         
        }

    }
}
