using EnemApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Data.Mappings
{
    public class CandidatoConcursoMap: IEntityTypeConfiguration<CandidatoConcurso>
    {
        public void Configure(EntityTypeBuilder<CandidatoConcurso> builder)
        {
            builder.HasKey(cc => new { cc.CandidatoId, cc.ConcursoId });
            
            builder.HasOne(cc => cc.Candidato)
                .WithMany(c => c.CandidatosConcursos)
                .HasForeignKey(cc => cc.CandidatoId);
            
            builder.HasOne(cc => cc.Concurso)
                .WithMany(c => c.CandidatosConcursos)
                .HasForeignKey(cc => cc.ConcursoId);
        }
    }
}
