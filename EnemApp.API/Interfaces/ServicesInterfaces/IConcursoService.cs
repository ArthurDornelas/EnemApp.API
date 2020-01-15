using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Interfaces.ServicesInterfaces
{
    public interface IConcursoService
    {
        Concurso AddConcurso<TConcursoValidator>(Concurso concurso);
        Concurso UpdateConcurso<TConcursoValidator>(Concurso concurso);
        IEnumerable<Concurso> UpdateConcursos(IEnumerable<Concurso> concursos);
        Concurso GetConcurso(int idConcurso);
        IEnumerable<Concurso> GetConcursos();
        void DeleteConcurso(int idConcurso);
        public IEnumerable<Candidato> GetCandidatosConcurso(int id);
        public void AddCandidatosConcurso(int id);
    }
}
