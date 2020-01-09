using System.Collections.Generic;
using EnemApp.API.Models;

namespace EnemApp.API.Interfaces.ServicesInterfaces
{
    public interface ICandidatoService 
    {
        Candidato AddCandidato<TCandidatoValidator>(Candidato candidato);
        Candidato UpdateCandidato<TCandidatoValidator>(Candidato candidato);
        IEnumerable<Candidato> UpdateCandidatos(IEnumerable<Candidato> candidatos);
        Candidato GetCandidato(int idCandidato);
        IEnumerable<Candidato> GetCandidatos();
        void DeleteCandidato(int idCandidato);
        void RealizarConcurso(int numVags);

    }
}
