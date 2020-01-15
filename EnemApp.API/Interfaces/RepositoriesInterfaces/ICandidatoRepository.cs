using System.Collections.Generic;
using EnemApp.API.Models;

namespace EnemApp.API.Interfaces.RepositoriesInterfaces
{
    public interface ICandidatoRepository : IRepository<Candidato>
    {
        public IEnumerable<Candidato> UpdateCandidatos(IEnumerable<Candidato> candidatos);
        public IEnumerable<Concurso> GetConcursosCandidato(int id);
    }
}
