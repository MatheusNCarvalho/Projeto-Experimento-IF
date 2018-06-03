using IFExperiment.Domain.ExperimentContext.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFExperiment.Infra.Mapping
{
    public class BlocoMap : IEntityTypeConfiguration<Bloco>
    {
        
        public void Configure(EntityTypeBuilder<Bloco> builder)
        {
           builder.ToTable("Blocos");
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.NomeBloco).HasColumnType("varchar(5)").IsRequired();

            builder.HasOne(x => x.AreaExperimento)
                .WithMany(x => x.Blocos)
                .HasForeignKey(x => x.AreaExperimentoId)
                .IsRequired();
        }
    }
}
