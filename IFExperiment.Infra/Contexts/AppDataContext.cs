

using FluentValidator;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Infra.Mapping;
using IFExperiment.Shared;
using IFExperiment.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace IFExperiment.Infra.Contexts
{

    public class AppDataContext : DbContext
    {
        
        public DbSet<Experimento> Experimentos { get; set; }
        public DbSet<BlocoTratamento> BlocoTratamentos { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<AreaExperimento> AreaExperimentos { get; set; }
        public DbSet<ExperimentoTramento> ExperimentoTramentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ExperimentoMap());
            modelBuilder.ApplyConfiguration(new TratamentoMap());
            modelBuilder.ApplyConfiguration(new BlocoTratamentoMap());
            modelBuilder.ApplyConfiguration(new BlocoMap());
            modelBuilder.ApplyConfiguration(new AreaExperimentoMap());
            modelBuilder.ApplyConfiguration(new ExperimentoTratamentoMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder
                .UseNpgsql(Settings.ConnectionStringHomologacao);

            base.OnConfiguring(optionsBuilder);
        }

    }
}
