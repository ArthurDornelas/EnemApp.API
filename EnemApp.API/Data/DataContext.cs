using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Data.Mappings;
using EnemApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnemApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Value> Values { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Concurso> Concursos { get; set; }
        public DbSet<CandidatoConcurso> CandidatosConcursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidatoMap());
            modelBuilder.ApplyConfiguration(new ConcursoMap());
            modelBuilder.ApplyConfiguration(new CandidatoConcursoMap());
        }
    }
}
