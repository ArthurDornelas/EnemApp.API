using EnemApp.API.Data.Repositories;
using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Services
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }
        public Candidato AddCandidato(Candidato candidato)
        {
            if (candidato != null)
            {
                if (candidato.Nota >= 0 && candidato.Nota <= 100 && !candidato.Nome.Any(char.IsDigit) &&
                    !candidato.Cidade.Any(char.IsDigit))
                {
                    var candidatoDb = _candidatoRepository.AddCandidato(candidato);
                    return candidatoDb;
                }
            }

            return null;
        }

        public void DeleteCandidato(int idCandidato)
        {
            _candidatoRepository.DeleteCandidato(idCandidato);
        }

        public Candidato GetCandidato(int idCandidato)
        {
            var candidatoBd = _candidatoRepository.GetCandidato(idCandidato);

            return candidatoBd;
        }

        public IEnumerable<Candidato> GetCandidatos()
        {
            var candidatos = _candidatoRepository.GetCandidatos();

            return candidatos;
        }

        public Candidato UpdateCandidato(Candidato candidato)
        {
            if (candidato != null)
            {
                if (candidato.Nota >= 0 && candidato.Nota <= 100 && !candidato.Nome.Any(char.IsDigit) &&
                    !candidato.Cidade.Any(char.IsDigit))
                {
                    var candidatoDb = _candidatoRepository.AddCandidato(candidato);
                    return candidatoDb;
                }
            }

            return null;
        }

        public void RealizarConcurso(int numVagas)
        {
            var candidatos = GetCandidatos().OrderByDescending(c => c.Nota).ToList(); 
            var cont = 1;
            foreach (var Candidato in candidatos)
            {
                if (Candidato.Nota == 0) Candidato.Aprovado = false;
                else if (numVagas == candidatos.Count) Candidato.Aprovado = true;
                else if (cont <= numVagas) Candidato.Aprovado = true;
                else if (cont > numVagas) Candidato.Aprovado = false;
                cont++;
                var candidatoBd = UpdateCandidato(Candidato);
            }
        }
    }
}
