using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Models
{
    public class Candidato
    {
        private double nota;
        public int Id { get; set; }
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

    }
}
