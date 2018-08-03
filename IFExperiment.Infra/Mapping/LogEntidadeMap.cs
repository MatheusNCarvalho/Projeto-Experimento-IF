using System;
using IFExperiment.Domain.ExperimentContext.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFExperiment.Infra.Mapping
{
    public class LogEntidadeMap : IEntityTypeConfiguration<LogEntidade>
    {
        public void Configure(EntityTypeBuilder<LogEntidade> builder)
        {
            builder.ToTable("LogEntidades");
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.EntidadeAnterior).HasMaxLength(Int32.MaxValue);
            builder.Property(x => x.EntidadeNova).HasMaxLength(Int32.MaxValue);
            builder.Property(x => x.NomeClass).HasColumnType("varchar(60)");

        }
    }
}
