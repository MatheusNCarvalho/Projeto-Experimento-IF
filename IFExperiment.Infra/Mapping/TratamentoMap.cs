using IFExperiment.Domain.ExperimentContext.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFExperiment.Infra.Mapping
{
    public class TratamentoMap : IEntityTypeConfiguration<Tratamento>
    {

        public void Configure(EntityTypeBuilder<Tratamento> builder)
        {
            builder.ToTable("Tratamentos");
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
        }
    }
}
