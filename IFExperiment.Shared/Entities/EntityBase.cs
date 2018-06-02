using System;
using FluentValidator;
using IFExperiment.Domain.ExperimentContext.Enums;

namespace IFExperiment.Shared.Entities
{
    public abstract class EntityBase : Notifiable
    {
        public Guid Id { get; protected set; }
        public DateTime DataCadastrado { get; protected set; }
        public DateTime DataAlteracao { get; protected set; }
        public DateTime DataExclusao { get; protected set; }
        public ESimNao Excluido { get; protected set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
            DataCadastrado = DateTime.Now;
            Excluido = ESimNao.Nao;
        }

        public void AddExcluido(ESimNao status)
        {
            Excluido = status;
        }

        public virtual bool Validated()
        {
           return  Valid;
        }
    }
}
