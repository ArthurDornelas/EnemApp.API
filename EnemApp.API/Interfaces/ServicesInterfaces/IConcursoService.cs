using EnemApp.API.Models;
using EnemApp.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Interfaces.ServicesInterfaces
{
    public interface IConcursoService
    {
        ConcursoViewModel AddConcurso(ConcursoViewModel concursoVM);
        ConcursoViewModel UpdateConcurso(ConcursoViewModel concursoVM);
        IEnumerable<ConcursoViewModel> UpdateConcursos(IEnumerable<ConcursoViewModel> concursosVM);
        ConcursoViewModel GetConcurso(int idConcurso);
        ConcursoViewModel GetConcursoComCandidatos(int idConcurso);
        IEnumerable<ConcursoViewModel> GetConcursos();
        void DeleteConcurso(int idConcurso);
        public IEnumerable<CandidatoViewModel> GetCandidatosConcurso(int id);
        public void AddCandidatosConcurso(int id);
    }
}
