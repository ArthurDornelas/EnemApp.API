using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.ViewModels
{
    public class CandidatoConcursoViewModel
    {
        public int CandidatoId { get; set; }
        public int ConcursoId { get; set; }
        public DateTime DataConcurso { get; set; }
        public virtual CandidatoViewModel Candidato { get; set; }
        public virtual ConcursoViewModel Concurso { get; set; }
    }
}
