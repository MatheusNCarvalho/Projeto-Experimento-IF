using System;
using System.Collections.Generic;
using System.Linq;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class Bloco : EntityBase
    {

        private readonly IList<BlocoTratamento> _blocoPlantas;

        public Bloco(string nome, Experimento experimento)
        {
            NomeBloco = nome;
            Experimento = experimento;

            _blocoPlantas = new List<BlocoTratamento>();
        }
        //Para o EF
        protected Bloco()
        {
            _blocoPlantas = new List<BlocoTratamento>();
        }

        public string NomeBloco { get; protected set; }
        public Guid ExperimentoId { get; protected set; }
        public virtual Experimento Experimento { get; protected set; }
        // public Guid AreaExperimentoId { get; set; }
        //public virtual AreaExperimento AreaExperimento { get; protected set; }
        public virtual ICollection<BlocoTratamento> BlocoTratamentos => _blocoPlantas.ToArray();


        public void AddPlanta(BlocoTratamento tratamento)
        {
            _blocoPlantas.Add(tratamento);
        }
        public void RemovePlanta(BlocoTratamento tratamento)
        {
            _blocoPlantas.Remove(tratamento);
        }

       


    }
}