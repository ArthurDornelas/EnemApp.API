using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Models
{
    public class Concurso: BaseEntity
    {
        public Concurso()
        {
            CandidatosConcursos = new HashSet<CandidatoConcurso>();
        }
        private DateTime _dataRealizacao;
        public string Nome { get; set; }
        public DateTime DataRealizacao 
        { 
          get => _dataRealizacao; 
           
          set
          {
             _dataRealizacao = value.Date;
          }
            
        }
        public int NumeroVagas { get; set; }

        public virtual ICollection<CandidatoConcurso> CandidatosConcursos { get; set; }
    }
}
