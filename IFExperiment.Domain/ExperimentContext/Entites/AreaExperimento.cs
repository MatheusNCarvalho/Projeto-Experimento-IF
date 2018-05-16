using System.Collections.Generic;
using System.Linq;
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
        }
        public Experimento Experimentro { get; protected set; }
        public IReadOnlyCollection<Bloco> Blocos => _blocos.ToArray();

        public void AddBloco(Bloco bloco)
        {
            _blocos.Add(bloco);
        }

        public void RemoveBloco(Bloco bloco)
        {
            _blocos.Remove(bloco);
        }
    }
}
