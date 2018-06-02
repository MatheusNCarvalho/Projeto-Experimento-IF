using System;
using System.Collections.Generic;
using System.Linq;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class ColetaExperimento : EntityBase
    {


        public Guid AvaliacaoExperimentoId { get; protected set; }
        public AvaliacaoExperimento AvaliacaoExperimento { get; protected set; }
        public DateTime DataColeta { get; protected set; }
        //public ColetaExperimentoBlocoPlanta Type { get; set; }
        

        public void RealizarAvalicao(Bloco bloco, BlocoPlanta blocoPlanta, List<TipoAvaliacao> tipoAvaliacoes)
        {
            //Validar se o Tipo de Avaliação é a esolhida para o criterio de Avaliação
            foreach (var bloco1 in AvaliacaoExperimento.Experimento.AreaExperimento.Blocos.Where(item => item.Equals(bloco)))
            {
                foreach (var planta in bloco1.BlocoPlantas.Where(x => x.Equals(blocoPlanta)))
                {
                    planta.AddAllTipoAvalicao(tipoAvaliacoes);
                }
            }
        }
    }
}
