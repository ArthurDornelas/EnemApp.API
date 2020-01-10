using EnemApp.API.Data.Repositories;
using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Interfaces.RepositoriesInterfaces;
using EnemApp.API.Interfaces.ServicesInterfaces;
using EnemApp.API.Validators;
using FluentValidation;

namespace EnemApp.API.Services
{
    public class CandidatoService : BaseService<Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }
        public Candidato AddCandidato<TCandidatoValidator>(Candidato candidato)
        {
            _candidatoRepository.Add(candidato);
            return candidato;
        }

        public void DeleteCandidato(int idCandidato)
        {
            _candidatoRepository.Remove(idCandidato);
        }

        public Candidato GetCandidato(int idCandidato)
        {
            var candidatoBd = _candidatoRepository.GetById(idCandidato);

            return candidatoBd;
        }

        public IEnumerable<Candidato> GetCandidatos()
        {
            var candidatos = _candidatoRepository.SelectAll().ToList().OrderByDescending(x => x.Nota);

            return candidatos;
        }

        public Candidato UpdateCandidato<TCandidatoValidator>(Candidato candidato)
        {
            _candidatoRepository.Update(candidato);
            return candidato;
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
