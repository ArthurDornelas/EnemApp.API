using System.Collections.Generic;
using EnemApp.API.Models;
using EnemApp.API.ViewModels;

namespace EnemApp.API.Interfaces.ServicesInterfaces
{
    public interface ICandidatoService 
    {
        CandidatoViewModel AddCandidato(CandidatoViewModel candidatoVM);
        CandidatoViewModel UpdateCandidato(CandidatoViewModel candidatoVM);
        IEnumerable<CandidatoViewModel> UpdateCandidatos(IEnumerable<CandidatoViewModel> candidatosVM);
        CandidatoViewModel GetCandidato(int idCandidato);
        IEnumerable<CandidatoViewModel> GetCandidatos();
        void DeleteCandidato(int idCandidato);
        void RealizarConcurso(int numVags);
        public IEnumerable<ConcursoViewModel> GetConcursosCandidato(int id);
    }
}
