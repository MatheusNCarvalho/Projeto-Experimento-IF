using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class BlocoPlanta : EntityBase
    {
        public BlocoPlanta(string nome, Bloco bloco, Planta planta)
        {
            Nome = nome;
            Bloco = bloco;
            Planta = planta;
        }

        public string Nome { get; protected set; }
        public Bloco Bloco { get; protected set; }
        public Planta Planta { get; protected set; }

    }
}
