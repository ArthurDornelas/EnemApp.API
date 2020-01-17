﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Models
{
    public class Candidato : BaseEntity
    {
        public Candidato()
        {
            CandidatosConcursos = new HashSet<CandidatoConcurso>();
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

        public virtual ICollection<CandidatoConcurso> CandidatosConcursos { get; set; }

    }
}
