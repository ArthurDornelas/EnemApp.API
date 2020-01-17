using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.ViewModels
{
    public class CandidatoViewModel
    {
        public CandidatoViewModel()
        {
            CandidatosConcursos = new HashSet<CandidatoConcursoViewModel>();
        }
        private double nota;
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public bool Aprovado { get; set; }
        public double Nota
        {
            get => nota;
            set
            {
                nota = Math.Round(value, 2);
            }
        }

        public virtual ICollection<CandidatoConcursoViewModel> CandidatosConcursos { get; set; }
    }
}
