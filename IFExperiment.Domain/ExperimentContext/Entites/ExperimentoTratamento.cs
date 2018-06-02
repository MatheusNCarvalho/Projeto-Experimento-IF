using System;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class ExperimentoTramento : EntityBase
    {

        public ExperimentoTramento(Experimento experimento, Tratamento tratamento)
        {
           
            Experimento = experimento;
            Tratamento = tratamento;
        }

        public Guid AreaExperimentoId { get; protected set; }
        public Guid PlantaId { get; protected set; }
        public int Qtd { get; protected set; }
        public Experimento Experimento { get; protected set; }
        public Tratamento Tratamento { get; protected set; }

    }
}
