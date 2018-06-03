using System;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Domain.ExperimentContext.ValueObjects;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class Tratamento : EntityBase
    {
        public Tratamento(Nome nome)
        {
            Nome = nome;
        }

        //Para o EF
        protected Tratamento() { }
      
      

        public Nome Nome { get; protected set; }
        public EStatus Status { get; protected set; }
        public Guid ExperimentoTratamentoId { get; protected set; }
        public ExperimentoTramento ExperimentoTramento { get; protected set; }


        public void Ativo()
        {
            Status = EStatus.Ativo;
        }

        public void Inativo()
        {
            Status = EStatus.Inativo;
        }

        public override bool Validated()
        {
            if (Status.Equals(null))
                AddNotification("Status", "Status deve ser selecionado");

            AddNotifications(Nome.Notifications);

            return Valid;
        }
    }
}