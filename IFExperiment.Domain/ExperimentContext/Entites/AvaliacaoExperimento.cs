﻿using System;
using System.Collections.Generic;
using System.Linq;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class AvaliacaoExperimento : EntityBase
    {
        private readonly IList<TipoAvaliacao> _tipoAvaliacoes;

        public AvaliacaoExperimento(Experimento experimento)
        {
            DataAvalicao = DateTime.Now;
            Experimento = experimento;
            _tipoAvaliacoes = new List<TipoAvaliacao>();

        }

        public DateTime DataAvalicao { get; protected set; }
        public Experimento Experimento { get; protected set; }
        public IReadOnlyCollection<TipoAvaliacao> TipoAvaliacoes => _tipoAvaliacoes.ToArray();

        public void AddTipoAvaliacao(TipoAvaliacao tipoAvaliacao)
        {
            _tipoAvaliacoes.Add(tipoAvaliacao);
        }

        public void RemoveTipoAvaliacao(TipoAvaliacao tipoAvaliacao)
        {
            _tipoAvaliacoes.Remove(tipoAvaliacao);
        }

        public void RealizarAvalicao(Bloco bloco, BlocoPlanta blocoPlanta, List<TipoAvaliacao> tipoAvaliacoes)
        {
           //Validar se o Tipo de Avaliação é a esolhida para o criterio de Avaliação
            foreach (var bloco1 in Experimento.AreaExperimento.Blocos.Where(item => item.Equals(bloco)))
            {
                foreach (var planta in bloco1.BlocoPlantas.Where(x => x.Equals(blocoPlanta)))
                {
                    planta.AddAllTipoAvalicao(tipoAvaliacoes);
                }
            }
        }

    }
}
