using EnemApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Data.Mappings
{
    public class ConcursoMap: IEntityTypeConfiguration<Concurso>
    {
        public void Configure(EntityTypeBuilder<Concurso> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("nome");

            builder.Property(x => x.DataRealizacao).IsRequired().HasColumnName("data_realizacao");

            builder.Property(x => x.NumeroVagas).IsRequired().HasColumnName("numero_vagas");

        }
    }
}
