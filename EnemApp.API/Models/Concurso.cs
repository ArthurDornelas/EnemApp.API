using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Models
{
    public class Concurso: BaseEntity<Concurso>
    {
        public DateTime DataRealizacao { get; set; }
        public int NumeroVagas { get; set; }
        public ICollection<CandidatoConcurso> CandidatosConcursos { get; set; }
    }
}
