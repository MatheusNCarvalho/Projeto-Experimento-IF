using System.Data.Entity;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Infra.Contexts
{
    public class AppDataContext : DbContext
    {

        public AppDataContext()
        : base("AppConnStr")
        {

        }

        public DbSet<Experimento> Experimentos { get; set; }
    }
}
