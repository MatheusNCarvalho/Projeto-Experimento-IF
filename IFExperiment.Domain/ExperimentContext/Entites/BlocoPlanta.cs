using System;
using System.Collections.Generic;
using System.Linq;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class BlocoPlanta : EntityBase
    {
        private readonly IList<TipoAvaliacao> _tipoAvalicoes;

        public BlocoPlanta(string nomeParcela, Bloco bloco, Tratamento tratamento)
        {

            NomeParcela = nomeParcela;
            Bloco = bloco;
            Tratamento = tratamento;
            _tipoAvalicoes = new List<TipoAvaliacao>();
        }

        public string NomeParcela { get; protected set; }
        public Bloco Bloco { get; protected set; }
        public DateTime DataAvaliacao { get; protected set; }
        public Tratamento Tratamento { get; protected set; }
        public IReadOnlyCollection<TipoAvaliacao> TipoAvaliacoes => _tipoAvalicoes.ToArray();

        public void AddTipoAvaliacao(TipoAvaliacao artefato)
        {
            _tipoAvalicoes.Add(artefato);
        }

        public void AddAllTipoAvalicao(List<TipoAvaliacao> tipoAvaliacaos)
        {
            DataAvaliacao = DateTime.Now;
            foreach (var tipoAvaliacao in tipoAvaliacaos)
            {
                _tipoAvalicoes.Add(tipoAvaliacao);
            }
        }

        public void RemoveTipoAvaliacao(TipoAvaliacao artefato)
        {
            _tipoAvalicoes.Remove(artefato);
        }

    }
}
