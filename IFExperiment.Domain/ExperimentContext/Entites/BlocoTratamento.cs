using System;
using System.Collections.Generic;
using System.Linq;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class BlocoTratamento : EntityBase
    {
        //private readonly IList<TipoAvaliacao> _tipoAvalicoes;

        public BlocoTratamento(string nomeParcela, Bloco bloco, Tratamento tratamento)
        {

            NomeParcela = nomeParcela;
            Bloco = bloco;
            Tratamento = tratamento;
            //_tipoAvalicoes = new List<TipoAvaliacao>();
        }

        //Para o EF
        protected BlocoTratamento() { }
       

        public string NomeParcela { get; protected set; }
        public Guid TratamentoId { get; protected set; }
        public Guid BlocoId { get; protected set; }
        public virtual Bloco Bloco { get; protected set; }
        public DateTime DataAvaliacao { get; protected set; }
        public virtual Tratamento Tratamento { get; protected set; }
        //public IReadOnlyCollection<TipoAvaliacao> TipoAvaliacoes => _tipoAvalicoes.ToArray();

        //public void AddTipoAvaliacao(TipoAvaliacao artefato)
        //{
        //    _tipoAvalicoes.Add(artefato);
        //}

        //public void AddAllTipoAvalicao(List<TipoAvaliacao> tipoAvaliacaos)
        //{
        //    DataAvaliacao = DateTime.Now;
        //    foreach (var tipoAvaliacao in tipoAvaliacaos)
        //    {
        //        _tipoAvalicoes.Add(tipoAvaliacao);
        //    }
        //}

        //public void RemoveTipoAvaliacao(TipoAvaliacao artefato)
        //{
        //    _tipoAvalicoes.Remove(artefato);
        //}

    }
}
