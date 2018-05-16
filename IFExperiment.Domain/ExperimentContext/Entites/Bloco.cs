using System.Collections.Generic;
using System.Linq;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class Bloco : EntityBase
    {

        private readonly IList<BlocoPlanta> _blocoPlantas;

        public Bloco(string nome)
        {
            NomeBloco = nome;

            _blocoPlantas = new List<BlocoPlanta>();
        }

        public string NomeBloco { get; protected set; }
        public IReadOnlyCollection<BlocoPlanta> BlocoPlantas => _blocoPlantas.ToArray();


        public void AddPlanta(int index, BlocoPlanta planta)
        {
            _blocoPlantas.Add(planta);
        }
        public void RemovePlanta(BlocoPlanta planta)
        {
            _blocoPlantas.Remove(planta);
        }



    }
}