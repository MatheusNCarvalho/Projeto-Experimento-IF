using IFExperiment.Domain.ExperimentContext.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFExperiment.Infra.Mapping
{
    public class ExperimentoTratamentoMap : IEntityTypeConfiguration<ExperimentoTramento>
    {
        
        public void Configure(EntityTypeBuilder<ExperimentoTramento> builder)
        {
            builder.ToTable("ExperimentosTratamentos");
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(x => x.Experimento)
                .WithMany(x => x.ExperimentoTramentos)
                .HasForeignKey(x => x.ExperimentoId)
                .IsRequired();

            builder.HasOne(x => x.Tratamento)
                .WithOne(x => x.ExperimentoTramento);
        }
    }
}
