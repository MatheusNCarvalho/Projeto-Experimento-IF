using IFExperiment.Domain.ExperimentContext.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFExperiment.Infra.Mapping
{
    public class ExperimentoMap : IEntityTypeConfiguration<Experimento>
    {


        public void Configure(EntityTypeBuilder<Experimento> builder)
        {
            builder.ToTable("Experimentos");
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

          
            builder.OwnsOne(x => x.Nome, nome =>
            {
                nome.Property(x => x.Valor)
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(255)")
                    .IsRequired();
            });

            builder.Property(x => x.Codigo).HasColumnType("varchar(100)").IsRequired();

        }
    }
}

