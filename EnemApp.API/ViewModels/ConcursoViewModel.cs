using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.ViewModels
{
    public class ConcursoViewModel
    {
        public ConcursoViewModel()
        {
            CandidatosConcursos = new HashSet<CandidatoConcursoViewModel>();
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

        public virtual ICollection<CandidatoConcursoViewModel> CandidatosConcursos { get; set; }
    }
}
