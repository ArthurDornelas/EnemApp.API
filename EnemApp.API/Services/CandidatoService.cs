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
            var candidatoBd = _candidatoRepository.AddCandidato(candidato);

            return candidatoBd;
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
            var candidatoBd = _candidatoRepository.UpdateCandidato(candidato);

            return candidatoBd;
        }
    }
}
