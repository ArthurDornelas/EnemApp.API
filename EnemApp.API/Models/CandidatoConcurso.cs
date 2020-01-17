﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Models
{
    public class CandidatoConcurso : BaseEntity
    {
        public int CandidatoId { get; set; }
        public int ConcursoId { get; set; }
        public DateTime DataConcurso { get; set; }
        public virtual Candidato Candidato { get; set; }
        public virtual Concurso Concurso { get; set; }
    }
}
