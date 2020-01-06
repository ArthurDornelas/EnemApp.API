using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Services
{
    public interface ICandidatoService
    {
        Candidato AddCandidato(Candidato candidato);

        Candidato UpdateCandidato(Candidato candidato);

        Candidato GetCandidato(int idCandidato);

        IEnumerable<Candidato> GetCandidatos();

        void DeleteCandidato(int idCandidato);

    }
}
