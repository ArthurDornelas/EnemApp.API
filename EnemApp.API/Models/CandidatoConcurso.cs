using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Models
{
    public class CandidatoConcurso
    {
        public CandidatoConcurso()
        {
            Candidato = new Candidato();
            Concurso = new Concurso();
        }
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
        public int ConcursoId { get; set; }
        public Concurso Concurso { get; set; }
    }
}
