using System;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class ExperimentoPlanta : EntityBase
    {

        public ExperimentoPlanta(Experimento experimento, Planta planta)
        {
           
            Experimento = experimento;
            Planta = planta;
        }

        public Guid AreaExperimentoId { get; set; }
        public Guid PlantaId { get; set; }
        public Experimento Experimento { get; protected set; }
        public Planta Planta { get; protected set; }

    }
}
