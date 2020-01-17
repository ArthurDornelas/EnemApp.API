using EnemApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EnemApp.API.Data.Mappings
{
    public class CandidatoConcursoMap : IEntityTypeConfiguration<CandidatoConcurso>
    {
        public void Configure(EntityTypeBuilder<CandidatoConcurso> builder)
        {
            builder.ToTable("CandidatosConcursos");

            builder.HasKey(cc => cc.Id);

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.CandidatoId)
                .HasColumnName("CandidatoId");

            builder.Property(p => p.ConcursoId)
                .HasColumnName("ConcursoId");

            builder.Property(p => p.DataConcurso)
                .HasDefaultValue(DateTime.Now)
                .HasColumnName("DataConcurso");

            builder.HasOne(cc => cc.Candidato)
                .WithMany(c => c.CandidatosConcursos)
                .HasForeignKey(cc => cc.CandidatoId);

            builder.HasOne(cc => cc.Concurso)
                .WithMany(c => c.CandidatosConcursos)
                .HasForeignKey(cc => cc.ConcursoId);

        }
    }
}
