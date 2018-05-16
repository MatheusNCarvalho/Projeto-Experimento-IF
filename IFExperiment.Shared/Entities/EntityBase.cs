using System;
using FluentValidator;

namespace IFExperiment.Shared.Entities
{
    public abstract class EntityBase : Notifiable
    {
        public Guid Id { get; set; }
        public DateTime DataCadastrado { get; set; }
        public DateTime DataAlteracao { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual bool Validated()
        {
           
           return  Valid;
        }
    }
}
