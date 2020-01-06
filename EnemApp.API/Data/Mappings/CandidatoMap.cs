using EnemApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Data.Mappings
{
    public class CandidatoMap : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("nome");

            builder.Property(x => x.Cidade).HasMaxLength(100).IsRequired().HasColumnName("cidade");

            builder.Property(x => x.Nota).IsRequired().HasColumnName("nota");

            builder.Property(x => x.Aprovado).HasColumnName("aprovado");

        }
    }
}
