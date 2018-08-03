using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Domain.ExperimentContext.ValueObjects;
using IFExperiment.Shared.Entities;
using System.Runtime.Serialization;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    [DataContract]
    public class Tratamento : EntityBase
    {
        public Tratamento(Nome nome)
        {
            Nome = nome;
        }

        //Para o EF
        protected Tratamento() { }

        [DataMember]
        public Nome Nome { get; protected set; }

        public void Update(Nome nome)
        {
            Nome = nome;
        }

        public override bool Validated()
        {
            AddNotifications(Nome.Notifications);
            return Valid;
        }
    }
}