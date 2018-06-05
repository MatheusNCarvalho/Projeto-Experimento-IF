using System;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class ExperimentoTramento : EntityBase
    {

        public ExperimentoTramento(Guid experimentoId, Guid tratamentoId)
        {
            ExperimentoId = experimentoId;
            TratamentoId = tratamentoId;

        }

        public ExperimentoTramento(Experimento experimento, Tratamento tratamento)
        {
            Experimento = experimento;
            Tratamento = tratamento;
            ExperimentoId = experimento.Id;
            TratamentoId = tratamento.Id;
        }

        //Para o EF
        protected ExperimentoTramento() { }
       

        public Guid ExperimentoId { get; protected set; }
        public Guid TratamentoId { get; protected set; }
        public int Qtd { get; protected set; }
        public virtual  Experimento Experimento { get; protected set; }
        public virtual  Tratamento Tratamento { get; protected set; }

    }
}
