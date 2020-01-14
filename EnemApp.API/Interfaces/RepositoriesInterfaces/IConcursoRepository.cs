using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Interfaces.RepositoriesInterfaces
{
    public interface IConcursoRepository : IRepository<Concurso>
    {
        public IEnumerable<Concurso> UpdateConcursos(IEnumerable<Concurso> concursos);
        public IEnumerable<Candidato> GetCandidatosConcurso(int id);
        
    }
}
