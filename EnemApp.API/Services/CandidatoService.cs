using EnemApp.API.Data.Repositories;
using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            var candidatos = _candidatoRepository.GetCandidatos().ToList().OrderByDescending(x => x.Nota);

            return candidatos;
        }

        public Candidato UpdateCandidato(Candidato candidato)
        {
            if (candidato != null)
            {
                if (candidato.Nota >= 0 && candidato.Nota <= 100 && !candidato.Nome.Any(char.IsDigit) &&
                    !candidato.Cidade.Any(char.IsDigit))
                {
                    var candidatoDb = _candidatoRepository.UpdateCandidato(candidato);
                    return candidatoDb;
                }
            }

            return null;
        }

        public IEnumerable<Candidato> UpdateCandidatos(IEnumerable<Candidato> candidatos)
        {
            var candidatosDb = _candidatoRepository.UpdateCandidatos(candidatos);

            return candidatosDb;
        }

        public void RealizarConcurso(int numVagas)
        {
            var candidatos = GetCandidatos().OrderByDescending(c => c.Nota).ToList();
            foreach (var candidato in candidatos)
            {
                if (candidato.Nota > 0 && numVagas > 0)
                {
                    candidato.Aprovado = true;
                    numVagas--;
                }
                else
                {
                    candidato.Aprovado = false;
                }
            }
            var candidatoBd = UpdateCandidatos(candidatos);
        }
    }
}
