using EnemApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Data.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly DataContext _dbContext;

        public CandidatoRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Candidato AddCandidato(Candidato candidato)
        {
            _dbContext.Candidatos.Add(candidato);

            _dbContext.SaveChanges();

            return candidato;
        }

        public void DeleteCandidato(int idCandidato)
        {
            var candidato = _dbContext.Candidatos.FirstOrDefault(x => x.Id == idCandidato);

            if (candidato == null) return;

            _dbContext.Candidatos.Remove(candidato);

            _dbContext.SaveChanges();
        }

        public Candidato GetCandidato(int idCandidato)
        {
            var candidato = _dbContext.Candidatos.FirstOrDefault(x => x.Id == idCandidato);
            return candidato;
        }

        public IEnumerable<Candidato> GetCandidatos()
        {
            var candidatos = _dbContext.Candidatos.ToList();
            return candidatos;
        }

        public Candidato UpdateCandidato(Candidato candidato)
        {
            _dbContext.Candidatos.Update(candidato);
            _dbContext.SaveChanges();

            return candidato;
        }

        public IEnumerable<Candidato> UpdateCandidatos(IEnumerable<Candidato> candidatos)
        {
            _dbContext.Candidatos.UpdateRange(candidatos);
            _dbContext.SaveChanges();

            return candidatos;
        }
    }
}
