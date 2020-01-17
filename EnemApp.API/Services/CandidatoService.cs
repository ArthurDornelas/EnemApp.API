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
using EnemApp.API.ViewModels;
using AutoMapper;

namespace EnemApp.API.Services
{
    public class CandidatoService : BaseService<Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IMapper _mapper;

        public CandidatoService(ICandidatoRepository candidatoRepository, IMapper mapper)
        {
            _candidatoRepository = candidatoRepository;
            _mapper = mapper;
        }
        public CandidatoViewModel AddCandidato(CandidatoViewModel candidatoVM)
        {
            var candidato = _mapper.Map<Candidato>(candidatoVM);
            var candidatoBd = _candidatoRepository.Add(candidato);

            return _mapper.Map<CandidatoViewModel>(candidatoBd);
        }

        public void DeleteCandidato(int idCandidato)
        {
            _candidatoRepository.Remove(idCandidato);
        }

        public CandidatoViewModel GetCandidato(int idCandidato)
        {
            var candidatoBd = _candidatoRepository.GetById(idCandidato);
            var candidatoVW = _mapper.Map<CandidatoViewModel>(candidatoBd);

            return candidatoVW;
        }

        public IEnumerable<CandidatoViewModel> GetCandidatos()
        {
            var candidatosBd = _candidatoRepository.SelectAll().ToList().OrderByDescending(x => x.Nota);
            var candidatosVW = _mapper.Map<IEnumerable<CandidatoViewModel>>(candidatosBd);

            return candidatosVW;
        }

        public CandidatoViewModel UpdateCandidato(CandidatoViewModel candidatoVM)
        {
            var candidato = _mapper.Map<Candidato>(candidatoVM);
            var candidatoBd = _candidatoRepository.Update(candidato);

            return _mapper.Map<CandidatoViewModel>(candidatoBd);
        }

        public IEnumerable<CandidatoViewModel> UpdateCandidatos(IEnumerable<CandidatoViewModel> candidatosVM)
        {
            var candidatos = _mapper.Map<IEnumerable<Candidato>>(candidatosVM);
            var candidatosBd = _candidatoRepository.UpdateCandidatos(candidatos);

            return _mapper.Map<IEnumerable<CandidatoViewModel>>(candidatosBd);
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

        public IEnumerable<ConcursoViewModel> GetConcursosCandidato(int id)
        {
            var concursosBd = _candidatoRepository.GetConcursosCandidato(id);
            return _mapper.Map<IEnumerable<ConcursoViewModel>>(concursosBd);
        }

    }
}
