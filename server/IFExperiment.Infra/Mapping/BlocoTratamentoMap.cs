using System.ComponentModel.DataAnnotations.Schema;
using IFExperiment.Domain.ExperimentContext.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFExperiment.Infra.Mapping
{
    public class BlocoTratamentoMap : IEntityTypeConfiguration<BlocoTratamento>
    {
        
        public void Configure(EntityTypeBuilder<BlocoTratamento> builder)
        {
            builder.ToTable("BlocosTratamentos");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.NomeParcela).HasColumnType("varchar(5)").IsRequired();

            builder.HasOne(x => x.Bloco)
                .WithMany(x => x.BlocoTratamentos)
                .HasForeignKey(x => x.BlocoId);
        }
    }
}
