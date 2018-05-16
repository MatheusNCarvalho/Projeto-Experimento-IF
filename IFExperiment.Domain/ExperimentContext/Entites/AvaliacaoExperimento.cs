using System;
using System.Collections.Generic;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class AvaliacaoExperimento : EntityBase
    {
        private readonly IList<AreaExperimento> _areaExperimentos;

        public AvaliacaoExperimento(Experimento experimento)
        {
            DataAvalicao = DateTime.Now;
            Experimento = experimento;
            _areaExperimentos = new List<AreaExperimento>();

        }

        public DateTime DataAvalicao { get; protected set; }
        public Experimento Experimento { get; protected set; }

        public void AddTipoAvaliacao(TipoAvaliacao tipoAvaliacao)
        {

        }

    }
}
