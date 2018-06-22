using System;
using System.Collections.Generic;
using System.Linq;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class AreaExperimento : EntityBase
    {
        private readonly IList<Bloco> _blocos;

        public AreaExperimento(Experimento experimentro)
        {
            Experimentro = experimentro;
            _blocos = new List<Bloco>();
            Status = EStatus.Ativo;
        }

        //Para o EF
        protected AreaExperimento()
        {
            _blocos = new List<Bloco>();
        }
       

       
        public virtual ICollection<Bloco> Blocos => _blocos.ToArray();
        public EStatus Status { get; protected set; }
        public Guid ExperimentroId { get; protected set; }
        public Experimento Experimentro { get; protected set; }

        public void AddBloco(Bloco bloco)
        {
            _blocos.Add(bloco);
        }

        public void RemoveBloco(Bloco bloco)
        {
            _blocos.Remove(bloco);
        }

        public void Cancelar()
        {
            Status = EStatus.Cancelado;
        }
    }
}
